using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services.Interfaces;
using ClearBank.DeveloperTest.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace ClearBank.DeveloperTest.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDataStoreFactory dataStoreFactory;
        private readonly IPaymentValidatorFactory paymentValidatorFactory;

        public AccountService(IDataStoreFactory dataStoreFactory, IPaymentValidatorFactory paymentValidatorFactory)
        {
            this.dataStoreFactory = dataStoreFactory;
            this.paymentValidatorFactory = paymentValidatorFactory;
        }

        public bool CheckAccountStatus(Account account, PaymentScheme paymentScheme, decimal requestedAmount)
        {           

            if (account == null)
            {
                return false;
            }

            var paymentValidator = paymentValidatorFactory.GetPaymentValidator(paymentScheme);
            return paymentValidator.IsAccountAllowedToMakePayment(account, requestedAmount);

        }

        public Account GetAccount(string debtorAccountNumber)
        {
            var accountDataStore = dataStoreFactory.GetAccountDataStore();
            return accountDataStore.GetAccount(debtorAccountNumber);
        }       

        public void UpdateAccount(Account account)
        {
            var accountDataStore = dataStoreFactory.GetAccountDataStore();
            accountDataStore.UpdateAccount(account);
        }
    }
}
