using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services.Interfaces
{
    public interface IPaymentValidatorFactory
    {
        IPaymentValidator GetPaymentValidator(PaymentScheme paymentScheme);
    }
}
