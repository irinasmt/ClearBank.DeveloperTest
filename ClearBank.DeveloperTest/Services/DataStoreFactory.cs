using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services
{
    public class DataStoreFactory: IDataStoreFactory
    {
        private readonly Settings settings;

        public DataStoreFactory(IOptions<Settings> settings)
        {
            this.settings = settings.Value;
        }

        public IDataStore GetAccountDataStore()
        {
            return settings.DataStoreType == "Backup" ? (IDataStore)new BackupAccountDataStore() : new AccountDataStore();
        }
    }
}
