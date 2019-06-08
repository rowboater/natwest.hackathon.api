using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.Model.TransactionModels
{
    public class Balance
    {
        public string CreditDebitIndicator { get; set; }
        public string Type { get; set; }
        public Amount2 Amount { get; set; }
    }
}
