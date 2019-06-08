using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.Model.TransactionModels
{
    public class Transaction
    {
        public string AccountId { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Status { get; set; }
        public DateTime BookingDateTime { get; set; }
        public Amount Amount { get; set; }
        public ProprietaryBankTransactionCode ProprietaryBankTransactionCode { get; set; }
        public Balance Balance { get; set; }
    }
}
