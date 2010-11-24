using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.Configuration;
using GuardianReviews.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Should;
namespace GuardianReviews.Tests.Storage
{
    [TestClass]
    public class TestAzureTableContext
    {
        private CloudStorageAccount _account;

        public TestAzureTableContext()
        {
            CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
                configSetter(ConfigurationHelper.GetConfigValue(configName)));
            _account = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
        }
        [TestMethod]
        public void Test_AzureContext_CreateTables()
        {
            var client = _account.CreateCloudTableClient();
            foreach (var table in client.ListTables())
            {
                client.DeleteTable(table);
            }

            AzureTableContext.CreateTables();
            client.ListTables().Count().ShouldEqual(1);

            var context = new AzureTableContext();
            context.AddToMenus(new MenuItemRow { Name = "blah", CreatedOn = DateTime.Now });
            context.AddToMenus(new MenuItemRow { Name = "test", CreatedOn = DateTime.Now.AddDays(-7) });
            context.SaveChanges();

            var results = from c in context.CreateQuery<MenuItemRow>("Menu") select c;

            var query = results.AsTableServiceQuery();
            //var query = context.Menu;
            
            var queryResults = query.Execute();
            queryResults.Count().ShouldEqual(2);

            

        }

        [TestMethod]
        public void CanCreateTable()
        {
            var tableName = "Menu";

            var tableServiceContext = new TableServiceContext(_account.TableEndpoint.ToString(), _account.Credentials);

            _account.CreateCloudTableClient().DeleteTableIfExist(tableName);
            _account.CreateCloudTableClient().CreateTableIfNotExist(tableName);

            tableServiceContext.AddObject(tableName, new MenuItemRow() { Name = "blah", CreatedOn = DateTime.Now });
            tableServiceContext.AddObject(tableName, new MenuItemRow() { Name = "test", CreatedOn = DateTime.Now.AddDays(-7) });
            tableServiceContext.SaveChanges();


            var results = from c in tableServiceContext.CreateQuery<MenuItemRow>(tableName) select c;

            var query = results.AsTableServiceQuery<MenuItemRow>();
            var queryResults = query.Execute();
            queryResults.Count().ShouldEqual(2);
        }
    }
}
