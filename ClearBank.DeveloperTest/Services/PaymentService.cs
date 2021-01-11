using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        public IAccountService accountService { get; set; }
        public PaymentService(IAccountService accountService)
        {
            this.accountService = accountService;
        }
               

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var dataStoreType = ConfigurationManager.AppSettings["DataStoreType"];

            IDataStore accountDataStore = accountService.GetAccountDataStore(dataStoreType);
            Account account = accountDataStore.GetAccount(request.DebtorAccountNumber);

            var result = accountService.GetAccountStatus(account, request.PaymentScheme, request.Amount) ;            

            if (result.Success)
            {
                account.Balance -= request.Amount;
                accountDataStore.UpdateAccount(account);
            }

            return result;
        }
    }
}
