using System;
using System.Collections.Generic;

namespace JsonToggler
{
    public interface IFeature
    {
        string Name { get; set; }

        EnvironmentEnum Environment { get; set; }

        PlatformEnum Platform { get; set; }

        /// <summary>
        /// A type of query to run
        /// </summary>
        CommandTypeEnum? CommandType { get; set; }

        /// <summary>
        /// The query to run to determine if the feature should be enabled/disabled.
        /// </summary>
        string Command { get; set; }

        /// <summary>
        /// The connection string to use if the CommanTypeEnum is SQL.
        /// This is the connection info the command will be ran against 
        /// to determine if the Feature should be enabled/disabled.
        /// </summary>
        string ConnectionStringName { get; set; }

        List<string> FilterValues { get; set; }

        bool IsSubFeature { get; }

        List<string> SpecificEntities { get; }

        bool IsEnabled();
    }
}
