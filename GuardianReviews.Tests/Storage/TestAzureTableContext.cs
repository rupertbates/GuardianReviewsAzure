using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Guardian.Configuration;
using GuardianReviews.Domain.Enumerations;
using GuardianReviews.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;
using Should;
using GuardianReviews.Storage.TableEntities;
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
            AzureTableContext.DeleteTables();
            AzureTableContext.CreateTables();
            var client = _account.CreateCloudTableClient();
            client.ListTables().Count().ShouldEqual(1);

            var context = new AzureTableContext();
            context.AddEntity(new ReviewEntity { Title = "blah", PublicationDate = DateTime.Now, StarRating = (int)StarRatings.Three });
            context.AddEntity(new ReviewEntity() { Title = "test", PublicationDate = DateTime.Now.AddDays(-7) });
            context.SaveChanges();

            var queryResults = context.Reviews.Execute();
            queryResults.Count().ShouldEqual(2);



        }
        [TestMethod]
        public void Test_AzureContext_Enums()
        {
            AzureTableContext.DeleteTables();
            AzureTableContext.CreateTables();

            var context = new AzureTableContext();
            context.AddEntity(new ReviewEntity { Title = "blah", PublicationDate = DateTime.Now, StarRating = (int) StarRatings.Three });
            context.AddEntity(new ReviewEntity() { Title = "test", PublicationDate = DateTime.Now.AddDays(-7) });
            context.SaveChanges();

            var results = context.Reviews.Where(r => r.StarRating == (int) StarRatings.Three);
            
            var query = results.AsTableServiceQuery();
            //var query = context.Menu;

            var queryResults = query.Execute();
            queryResults.Count().ShouldEqual(1);
            queryResults.First().StarRating.ShouldEqual((int)StarRatings.Three);



        }

        [TestMethod]
        public void CanCreateTable()
        {
            var tableName = "ReviewEntity";

            var tableServiceContext = new TableServiceContext(_account.TableEndpoint.ToString(), _account.Credentials);

            _account.CreateCloudTableClient().DeleteTableIfExist(tableName);
            _account.CreateCloudTableClient().CreateTableIfNotExist(tableName);

            tableServiceContext.AddObject(tableName, new ReviewEntity() { Title = "blah", PublicationDate = DateTime.Now });
            tableServiceContext.AddObject(tableName, new ReviewEntity() { Title = "test", PublicationDate = DateTime.Now.AddDays(-7) });
            tableServiceContext.SaveChanges();


            var results = from c in tableServiceContext.CreateQuery<ReviewEntity>(tableName) select c;

            var query = results.AsTableServiceQuery<ReviewEntity>();
            var queryResults = query.Execute();
            queryResults.Count().ShouldEqual(2);
        }
    }
}
