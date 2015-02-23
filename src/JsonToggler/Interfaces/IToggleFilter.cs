using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace JsonToggler
{
    public interface IToggleFilter
    {
        /// <summary>
        /// To filter a DataSet based upon a column name.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        DataSet FilterResult(DataSet data, string columnName);

        /// <summary>
        /// This will filter an IEnumerable collection of a type based upon the column name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        IEnumerable<T> FilterResult<T>(IEnumerable<T> data, string columnName);
    }
}
