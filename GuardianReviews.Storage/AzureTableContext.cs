using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.Configuration;
using GuardianReviews.Domain;
using GuardianReviews.Domain.Enumerations;
using GuardianReviews.Storage.TableEntities;

namespace GuardianReviews.Storage
{

    using System;
    using System.Configuration;
    using System.Data.Services.Common;
    using System.Linq;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.StorageClient;
    
    public class AzureTableContext : TableServiceContext
    {
        private static readonly CloudStorageAccount _account;

        #region Constructors
        static AzureTableContext()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
                configSetter(ConfigurationHelper.GetConfigValue(configName)));

            _account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
        }
        public AzureTableContext(): base(_account.TableEndpoint.ToString(), _account.Credentials)
        {

        }
        public AzureTableContext(string baseAddress, StorageCredentials credentials):base(baseAddress, credentials)
        {
            
        }
        #endregion

        public static void CreateTables()
        {
            var client = _account.CreateCloudTableClient();
            client.CreateTableIfNotExist(typeof(ReviewEntity).Name);

        }
        public static void DeleteTables()
        {
            var client = _account.CreateCloudTableClient();
            foreach (var table in client.ListTables())
            {
                client.DeleteTable(table);
            }
        }
        public CloudTableQuery<ReviewEntity> Reviews
        {
            get
            {
                return CreateQuery<ReviewEntity>(typeof(ReviewEntity).Name).AsTableServiceQuery();
            }
        }
        public void AddEntity<T>(T entity)
        {
            AddObject(typeof(T).Name, entity);
        }
    }
   
}
