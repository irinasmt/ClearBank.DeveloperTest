using ClearBank.DeveloperTest.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services.Interfaces
{
    public interface IDataStoreFactory
    {
        IDataStore GetAccountDataStore();
    }
}
