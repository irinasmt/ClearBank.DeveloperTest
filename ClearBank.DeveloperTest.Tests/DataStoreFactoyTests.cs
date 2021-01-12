using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Services.Interfaces;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using System.Configuration;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class DataStoreFactoyTests
    {
        private IDataStoreFactory dataStoreFactory;

        [SetUp]
        public void SetUp()
        {
            var settings = Options.Create(new Settings());
            dataStoreFactory = new DataStoreFactory(settings);
        }

        [Test]
        public void DataStoreTypeBackup_Returns_BackupAccountDataStore()
        {
            var appSettings = ConfigurationManager.AppSettings;
            appSettings["DataStoreType"] = "Backup";
            var dataStore = dataStoreFactory.GetAccountDataStore();
            Assert.IsInstanceOf<BackupAccountDataStore>(dataStore);
        }


        [Test]
        public void DataStoreTypeOther_Returns_AccountDataStore()
        {
            var appSettings = ConfigurationManager.AppSettings;
            appSettings["DataStoreType"] = "Other";
            var dataStore = dataStoreFactory.GetAccountDataStore();
            Assert.IsInstanceOf<AccountDataStore>(dataStore);
        }

    }
}
