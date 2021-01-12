using ClearBank.DeveloperTest.Services.Interfaces;
using ClearBank.DeveloperTest.Types;

namespace ClearBank.DeveloperTest.Services.Validators
{
    public class PaymentValidatorFactory : IPaymentValidatorFactory
    {
        public IPaymentValidator GetPaymentValidator(PaymentScheme paymentScheme)
        {
            switch (paymentScheme)
            {                
                case PaymentScheme.FasterPayments:
                    return new FasterPaymentsPaymentValidator();
                case PaymentScheme.Chaps:
                    return new ChapsPaymentValidator();
                case PaymentScheme.Bacs:
                default:
                    return new BacsPaymentValidator();
            }
        }
    }
}
