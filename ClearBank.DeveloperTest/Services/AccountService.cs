using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        public IDataStore GetAccountDataStore(string dataStoreType)
        {
            return dataStoreType == "Backup" ? (IDataStore)new BackupAccountDataStore() : new AccountDataStore();
        }

        public MakePaymentResult GetAccountStatus(Account account, PaymentScheme paymentScheme, decimal requestedAmount)
        {
            var result = new MakePaymentResult()
            {
                Success=true
            };

            if (account == null)
            {
                result.Success = false;
                return result;
            }
           
            switch (paymentScheme)
            {
                case PaymentScheme.Bacs:                   
                    if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                    {
                        result.Success = false;
                    }
                    break;

                case PaymentScheme.FasterPayments:                    
                    if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments) || account.Balance < requestedAmount)
                    {
                        result.Success = false;
                    }                   
                    break;

                case PaymentScheme.Chaps:                    
                    if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) || account.Status != AccountStatus.Live)
                    {
                        result.Success = false;
                    }                   
                    break;
            }

            return result;
        }
    }
}
