﻿using ClearBank.DeveloperTest.Services.Interfaces;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClearBank.DeveloperTest.Services
{
    public class ChapsPaymentValidator : IPaymentValidator
    {
        public bool IsAccountAllowedToMakePayment(Account account, decimal requestedAmount)
        {
            if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps) || account.Status != AccountStatus.Live)
            {
               return  false;
            }
            return true;
        }
    }
}
