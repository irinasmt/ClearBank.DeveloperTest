using ClearBank.DeveloperTest.Services.Interfaces;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services
{
    public class BacsPaymentValidator : IPaymentValidator
    {
        public bool IsAccountAllowedToMakePayment(Account account, decimal requestedAmount)
        {
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
            {
                return false;
            }
            return true;
        }
    }
}
