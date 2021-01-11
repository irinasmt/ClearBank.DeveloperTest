using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private IAccountService accountService;

        [SetUp]
        public void SetUp()
        {
            accountService = new AccountService();
        }

        [Test]
        public void DataStoreTypeBackup_Returns_BackupAccountDataStore()
        {
            var dataStore = accountService.GetAccountDataStore("Backup");
            Assert.IsInstanceOf<BackupAccountDataStore>(dataStore);
        }

        [Test]
        public void DataStoreTypeOther_Returns_AccountDataStore()
        {
            var dataStore = accountService.GetAccountDataStore("Other");
            Assert.IsInstanceOf<AccountDataStore>(dataStore);
        }

        [Test]
        public void AccountNull_Returns_MakePayment_False()
        {
            var makePaymentResult = accountService.GetAccountStatus(null, Types.PaymentScheme.Bacs, 0);
            Assert.False(makePaymentResult.Success);
        }

        [Test]
        public void Account_FasterPayments_PaymentScheme_Bacs_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.Bacs, 0);
            Assert.False(makePaymentResult.Success);
        }

        [Test]
        public void Account_Bacs_PaymentScheme_Bacs_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.Bacs, 0);
            Assert.True(makePaymentResult.Success);
        }

        [Test]
        public void Account_Bacs_PaymentScheme_FasterPayments_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.FasterPayments, 0);
            Assert.False(makePaymentResult.Success);
        }

        [Test]
        public void Account_FasterPayments_Balance_0_RequestedAmount_1_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance=0
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.FasterPayments, 1);
            Assert.False(makePaymentResult.Success);
        }

        [Test]
        public void Account_FasterPayments_Balance_2_RequestedAmount_1_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.FasterPayments,
                Balance = 2
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.FasterPayments, 1);
            Assert.True(makePaymentResult.Success);
        }

        [Test]
        public void Account_Bacs_PaymentScheme_Chaps_Returns_MakePayment_False()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Bacs,
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.Chaps, 0);
            Assert.False(makePaymentResult.Success);
        }

        [Test]
        public void Account_Chaps_Live_PaymentScheme_Chaps_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status=AccountStatus.Live
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.Chaps, 0);
            Assert.True(makePaymentResult.Success);
        }

        [Test]
        public void Account_Chaps_Disabled_PaymentScheme_Chaps_Returns_MakePayment_True()
        {
            var account = new Account()
            {
                AllowedPaymentSchemes = AllowedPaymentSchemes.Chaps,
                Status = AccountStatus.Disabled
            };
            var makePaymentResult = accountService.GetAccountStatus(account, Types.PaymentScheme.Chaps, 0);
            Assert.False(makePaymentResult.Success);
        }
    }
}
