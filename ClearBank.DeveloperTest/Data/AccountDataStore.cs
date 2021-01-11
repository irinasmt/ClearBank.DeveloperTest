using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Data
{
    public class AccountDataStore :IDataStore
    {
        public Types.Account GetAccount(string accountNumber)
        {
            // Access database to retrieve account, code removed for brevity 
            return new Types.Account();
        }

        public void UpdateAccount(Types.Account account)
        {
            // Update account in database, code removed for brevity
        }
    }
}
