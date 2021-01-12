using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ClearBank.DeveloperTest
{
    public class Settings
    {
        public string DataStoreType => ConfigurationManager.AppSettings["DataStoreType"];
    }
}
