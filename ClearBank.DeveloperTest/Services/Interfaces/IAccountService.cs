using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services
{
    public interface IAccountService
    {        
        Account GetAccount(string debtorAccountNumber);
        bool CheckAccountStatus(Account account, PaymentScheme paymentScheme, decimal requestedAmount);
        void UpdateAccount(Account account);
    }
}
