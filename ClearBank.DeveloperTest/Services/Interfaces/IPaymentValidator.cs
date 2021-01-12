using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services.Interfaces
{
    public interface IPaymentValidator
    {
        bool IsAccountAllowedToMakePayment(Account account, decimal requestedAmount);
    }
}
 