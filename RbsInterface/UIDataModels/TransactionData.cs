using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.UIDataModels
{
    public class TransactionData
    {
        public DateTime TransactionDateTime { get; set; } 
        public bool debit { get; set; }
        public bool credit { get; set; }
        public string transactionType { get; set; }
        public string feeType { get; set; }
    }
}
