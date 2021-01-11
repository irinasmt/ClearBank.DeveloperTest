using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {
        IDataStore GetAccountDataStore(string dataStoreType);
        MakePaymentResult GetAccountStatus(Account account, PaymentScheme paymentScheme, decimal requestedAmount);
    }
}
