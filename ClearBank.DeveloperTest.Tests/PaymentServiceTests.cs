using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Types;
using Moq;
using NUnit.Framework;

namespace ClearBank.DeveloperTest.Tests
{
    [TestFixture]
    public class PaymentServiceTests
    {
        private IPaymentService paymentService;
        private Mock<IAccountService> mockAccountService;
        private Mock<IDataStore> mockDataStore;

        [SetUp]
        public void SetUp()
        {
            mockAccountService = new Mock<IAccountService>();
            mockDataStore = new Mock<IDataStore>();
            paymentService = new PaymentService(mockAccountService.Object);
        }

        [Test]
        public void AccountStatus_False_Returns_MakePayment_False()
        {
            mockAccountService.Setup(f => f.GetAccountDataStore(It.IsAny<string>())).Returns(new AccountDataStore());
            mockAccountService.Setup(f => f.GetAccountStatus(It.IsAny<Account>(), PaymentScheme.Bacs, 1 )).Returns(new MakePaymentResult { Success = false });
            mockDataStore.Setup(f => f.GetAccount(It.IsAny<string>())).Returns(new Account());

            var request = new MakePaymentRequest
            {
                PaymentScheme = PaymentScheme.Bacs,
                Amount=1
            };
            var makePaymentReult = paymentService.MakePayment(request);

            Assert.False(makePaymentReult.Success);
        }

        [Test]
        public void AccountStatus_True_Returns_MakePayment_True()
        {
            var debtorAccountNumber = "123";
            mockAccountService.Setup(f => f.GetAccountDataStore(It.IsAny<string>())).Returns(mockDataStore.Object);
            var account = new Account() { Balance = 3 };
            mockDataStore.Setup(f => f.GetAccount(debtorAccountNumber)).Returns(account);
            mockAccountService.Setup(f => f.GetAccountStatus(account, PaymentScheme.Bacs, 2)).Returns(new MakePaymentResult { Success = true });


            var request = new MakePaymentRequest
            {
                PaymentScheme = PaymentScheme.Bacs,
                Amount = 2,
                DebtorAccountNumber=debtorAccountNumber
            };
            var makePaymentReult = paymentService.MakePayment(request);

            Assert.True(makePaymentReult.Success);
            Assert.AreEqual(1,account.Balance);
        }

    }
}
