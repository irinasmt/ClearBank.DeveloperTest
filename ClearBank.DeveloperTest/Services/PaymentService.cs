using ClearBank.DeveloperTest.Types;

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
            var result = new MakePaymentResult();
            Account account = accountService.GetAccount(request.DebtorAccountNumber);
            result.Success = accountService.CheckAccountStatus(account, request.PaymentScheme, request.Amount);


            if (result.Success)
            {
                account.Balance -= request.Amount;
                accountService.UpdateAccount(account);
            }

            return result;
        }
    }
}
