using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guardian.Configuration;

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
        private const string _menu = "Menu";
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
            CloudTableClient.CreateTablesFromModel(typeof(AzureTableContext), _account.TableEndpoint.ToString(), _account.Credentials);

        }
        public IQueryable<MenuItemRow> Menu
        {
            get
            {
                return CreateQuery<MenuItemRow>(_menu).AsTableServiceQuery();
            }
        }
        //TODO: doesn't really work investigate using attributes to work out the tablename
        private void AddEntity<T>(T entity)
        {
            AddObject(typeof(T).Name, entity);
        }
        public void AddToMenus(MenuItemRow menu)
        {
            AddObject(_menu, menu);
        }
    }

    [EntityPropertyMapping("Name", SyndicationItemProperty.Title, SyndicationTextContentKind.Plaintext, true)]
    public class MenuItemRow :  TableServiceEntity
    {
        public MenuItemRow():base(Guid.NewGuid().ToString(), "")
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
