using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.Model.AccountModels
{
    public class Account
    {
        public string AccountId { get; set; }
        public string Currency { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public string Description { get; set; }
        public string Nickname { get; set; }
        public List<Account2> Account { get; set; }
    }
}
