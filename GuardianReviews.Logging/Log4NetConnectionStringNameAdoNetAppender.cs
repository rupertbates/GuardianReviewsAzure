using System.Configuration;
using log4net.Core;

namespace log4net.Appender
{
    /// <summary>
    /// Allows to use a connection string specified in the 
    /// <see cref="ConfigurationManager.ConnectionStrings"/> section of an application
    /// configuration file.
    /// </summary>
    /// <remarks>
    /// Such feature is already implemented in a log4net trunk (see
    /// https://issues.apache.org/jira/browse/LOG4NET-88). But it is not yet released.
    /// <para/>
    /// TODO: Remove this class as soon as log4net 1.2.11 is released.
    /// </remarks>
    public class Log4NetConnectionStringNameAdoNetAppender : AdoNetAppender
    {
        private string connectionStringName;

        /// <summary>
        /// Gets or sets the name of the connection string from the application
        /// configuration file.
        /// </summary>
        /// <value>The name of the connection string.</value>
        public string ConnectionStringName
        {
            get { return connectionStringName; }

            set
            {
                connectionStringName = value;

                if (!string.IsNullOrEmpty(connectionStringName))
                {
                    ConnectionStringSettings settings =
                        ConfigurationManager.ConnectionStrings[connectionStringName];
                    if (settings == null)
                    {
                        string msg = string.Format(
                            "Unable to find [{0}] ConfigurationManager.ConnectionStrings item",
                            connectionStringName);

                        throw new LogException(msg);
                    }

                    ConnectionString = settings.ConnectionString;
                }
            }
        }
    }
}