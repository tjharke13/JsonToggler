﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    public class JsonTogglerHelper
    {
        /// <summary>
        /// Determines if the feature toggle is enabled.
        /// </summary>
        /// <param name="featureToggle"></param>
        /// <returns></returns>
        public bool IsEnabled(IFeature featureToggle, EnvironmentEnum currentEnvironment, PlatformEnum currentPlatform, string specificEntityId, bool isTestMode, List<string> applications)
        {
            //If in test mode we want to enable all features.
            if (isTestMode)
                return true;

            if (featureToggle == null || featureToggle.Environment == EnvironmentEnum.NONE)
                return false;

            if (!string.IsNullOrEmpty(featureToggle.Application) && featureToggle.Application.ToUpper() != "ALL" && applications.Where(w => w.ToUpper() == featureToggle.Application.ToUpper() || w.ToUpper() == "ALL").Count() == 0)
                return false;

            var result = false;

            //TODO: Uncomment if we want a sub feature to be enabled if the 'parent' feature is enabled.
            //if (featureToggle.IsSubFeature && (!featureToggle.Environment.Has<EnvironmentEnum>(_currentEnvironment) || !featureToggle.Platform.Has<PlatformEnum>(_currentPlatform)))
            //{
            //    //If this is a subfeature and it is disabled we want to use the parent features 
            //    //value and check to see if the actual 'parent' feature is enabled.  
            //    var subToggleFeature = (SubFeatureToggle)featureToggle;
            //    featureToggle = (FeatureToggle)subToggleFeature.FeatureToggle;
            //}

            if (featureToggle.Environment.Has<EnvironmentEnum>(currentEnvironment) && featureToggle.Platform.Has<PlatformEnum>(currentPlatform))
            {
                if (string.IsNullOrEmpty(featureToggle.Command))
                    result = true;
                else if (featureToggle.CommandType != null)
                {
                    switch (featureToggle.CommandType)
                    {
                        case CommandTypeEnum.DateOnOrAfter:
                            try
                            {
                                var date = Convert.ToDateTime(featureToggle.Command);

                                if (date <= DateTime.UtcNow)
                                    return true;
                                else
                                    return false;
                            }
                            catch (Exception ex)
                            {
                                throw new JsonTogglerException(string.Format("Invalid format for commandType: {0} and command: {1}", featureToggle.CommandType.ToString()), ex);
                            }
                        case CommandTypeEnum.DateOnOrBefore:
                            try
                            {
                                var date = Convert.ToDateTime(featureToggle.Command);

                                if (date >= DateTime.UtcNow)
                                    return true;
                                else
                                    return false;
                            }
                            catch (Exception ex)
                            {
                                throw new JsonTogglerException(string.Format("Invalid format for commandType: {0} and command: {1}", featureToggle.CommandType.ToString()), ex);
                            }
                        case CommandTypeEnum.DatesBetween:
                            try
                            {
                                var dateStrings = featureToggle.Command.Split('|');
                                var beginningDate = Convert.ToDateTime(dateStrings[0].Trim());
                                var endDate = Convert.ToDateTime(dateStrings[1].Trim());

                                if (beginningDate >= DateTime.UtcNow && endDate <= DateTime.UtcNow)
                                    return true;
                                else
                                    return false;
                            }
                            catch (Exception ex)
                            {
                                throw new JsonTogglerException(string.Format("Invalid format for commandType: {0} and command: {1}", featureToggle.CommandType.ToString()), ex);
                            }
                        case CommandTypeEnum.SQL:
                            try
                            {
                                if (!string.IsNullOrEmpty(featureToggle.ConnectionStringName))
                                {
                                    var connString = ConfigurationManager.ConnectionStrings[featureToggle.ConnectionStringName].ConnectionString;

                                    if (connString != null && connString != null)
                                    {
                                        using (var sqlConn = new SqlConnection(connString))
                                        {
                                            var sqlCmd = new SqlCommand(featureToggle.Command, sqlConn);
                                            sqlConn.Open();

                                            var sqlResult = sqlCmd.ExecuteScalar();
                                            result = Convert.ToBoolean(sqlResult);
                                        }
                                    }
                                }
                                break;
                            }
                            catch (Exception ex)
                            {
                                throw new JsonTogglerException(string.Format("Invalid format for commandType: '{0}' and command: '{1}'", featureToggle.CommandType.ToString()), ex);
                            }
                        default:
                            throw new JsonTogglerException(string.Format("This command is not implemented. '{0}'", featureToggle.CommandType.ToString()));
                    }
                }
            }

            //Determine if this feature is supposed to be only for specific users.
            if (result && this.IsSpecificEntityFeature(featureToggle))
            {
                if (string.IsNullOrEmpty(specificEntityId))
                    return false;

                result = featureToggle.SpecificEntities.Where(w => w.Equals(specificEntityId, StringComparison.InvariantCultureIgnoreCase)).Count() > 0;
            }

            return result;
        }

        #region Filter

        /// <summary>
        /// Filters a dataset based upon the column and feature toggle.
        /// </summary>
        /// <returns></returns>
        public virtual DataSet FilterDataSet<TFilterType>(DataSet data, string columnName, IFeature featureToggle, bool isFeatureEnabled, bool showOnlyItemsSpecified = false)
        {
            var dt = data.Tables[0];
            var updatedDataTable = this.FilterDataTable<TFilterType>(dt, columnName, featureToggle, isFeatureEnabled, showOnlyItemsSpecified);


            data.Tables.RemoveAt(0);

            var dataTables = new List<DataTable>();
            dataTables.Add(updatedDataTable);

            //We want to make sure if their are multiple data tables that they are are in the same order.
            foreach (DataTable table in data.Tables)
            {
                dataTables.Add(table);
            }

            data.Tables.Clear();
            data.Tables.AddRange(dataTables.ToArray());
            data.AcceptChanges();

            return data;
        }

        public virtual DataTable FilterDataTable<TFilterType>(DataTable data, string columnName, IFeature featureToggle, bool isFeatureEnabled, bool showOnlyItemsSpecified = false)
        {
            if (featureToggle.FilterValues != null && featureToggle.FilterValues.Count > 0)
            {
                var itemsToFilter = featureToggle.FilterValues;

                var filterList = new List<TFilterType>();

                //Convert each item to the type specified
                foreach (var item in itemsToFilter)
                {
                    var convertedValue = (TFilterType)System.ComponentModel.TypeDescriptor.GetConverter(typeof(TFilterType)).ConvertFromInvariantString(item.Trim());
                    filterList.Add(convertedValue);
                }

                if (!showOnlyItemsSpecified && !isFeatureEnabled)
                {
                    //Because this feature isn't enabled yet we want to remove the rows that are being added with this feature.
                    //Get list of Rows to Remove
                    var rowsToRemove = data.AsEnumerable().Where(r => filterList.Contains(r.Field<TFilterType>(columnName))).ToList();

                    //Filter Table
                    rowsToRemove.ForEach(r => data.Rows.Remove(r));
                }
                else if (showOnlyItemsSpecified && isFeatureEnabled)
                {
                    //Because this is a reverseFilter we aren't removing rows, but only showing specific ones that are defined in the feature.
                    //The feature must be enabled to show only these certain items.
                    //Get list of Rows to Remove
                    var rowsToShow = data.AsEnumerable().Where(r => !filterList.Contains(r.Field<TFilterType>(columnName))).ToList();

                    //Filter Table
                    data.Rows.Clear();
                    data.Rows.Add(rowsToShow);
                }
            }

            data.AcceptChanges();

            return data;
        }


        /// <summary>
        /// Filters a collection of a generic type based upon the provided info.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TFilterType"></typeparam>
        /// <param name="data"></param>
        /// <param name="columnName"></param>
        /// <param name="featureToggle"></param>
        /// <param name="filterItemsIfEnabled"></param>
        /// <returns>Filtered collection of T.</returns>
        public virtual IEnumerable<T> FilterCollection<T, TFilterType>(IEnumerable<T> data, string columnName, IFeature featureToggle, bool isFeatureEnabled, bool filterItemsIfEnabled = false)
        {
            if (featureToggle.FilterValues != null && featureToggle.FilterValues.Count > 0)
            {
                var enabledEnvironments = (EnvironmentEnum)featureToggle.Environment;
                var itemsToFilter = featureToggle.FilterValues;

                if ((!filterItemsIfEnabled && !isFeatureEnabled) || (filterItemsIfEnabled && isFeatureEnabled))
                {
                    if (string.IsNullOrEmpty(columnName))
                    {
                        data = data.Where(w => !itemsToFilter.Contains(w.ToString()));
                    }
                    else
                    {
                        OperationEnum operationType;

                        if (filterItemsIfEnabled)
                        {
                            //Because this feature is enabled and the filterItemsIfEnabled is true we will filter the values that 
                            //are supplied via the feature.
                            operationType = OperationEnum.Equals;
                        }
                        else
                        {
                            //Because this feature isn't enabled yet we want to remove the rows that are being added with this feature.
                            //These values are supplied via FilterValues.
                            operationType = OperationEnum.NotEquals;
                        }

                        var filterList = GetFilterList<TFilterType>(itemsToFilter, columnName, operationType);

                        var expr = ExpressionBuilder.GetExpression<T>(filterList).Compile();

                        data = data.Where(expr);
                    }

                }
            }

            return data;
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// This will return a query against the SpecificEntities collection
        /// If count > 0 this feature is specific to certain entities (companies/users).
        /// If count = 0 then this feature is for everyone.
        /// </summary>
        private bool IsSpecificEntityFeature(IFeature toggleFeature)
        {
            return toggleFeature.SpecificEntities != null && toggleFeature.SpecificEntities.Count > 0 && !string.IsNullOrEmpty(toggleFeature.SpecificEntities.FirstOrDefault());
        }

        private List<FilterInfo> GetFilterList<TFilterType>(List<string> itemsToFilter, string columnName, OperationEnum operation)
        {
            var result = new List<FilterInfo>();
            foreach (var fi in itemsToFilter)
            {
                var filter = new FilterInfo() { PropertyName = columnName, Operation = OperationEnum.NotEquals, Value = (TFilterType)System.ComponentModel.TypeDescriptor.GetConverter(typeof(TFilterType)).ConvertFromInvariantString(fi.Trim()) };
                result.Add(filter);
            }

            return result;
        }

        #endregion
    }
}
