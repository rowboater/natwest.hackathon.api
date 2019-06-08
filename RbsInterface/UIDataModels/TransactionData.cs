using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.UIDataModels
{
    public class TransactionData
    {
        public DateTime TransactionDateTime { get; set; } 
        public string creditOrDebit { get; set; }
        public string transactionType { get; set; }
        public bool isFee { get; set; }
        public string feeType { get; set; }
        public decimal amount { get; set; }
    }
}
