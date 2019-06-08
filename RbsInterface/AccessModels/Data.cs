﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.AccessModels
{
    public class Data
    {
        public Data()
        {
            Permissions = new List<string>
            {
                "ReadAccountsDetail",
                "ReadBalances",
                "ReadTransactionsCredits",
                "ReadTransactionsDebits",
                "ReadTransactionsDetail"
            };
        }

        public List<String> Permissions { get; set; }

        public string Risk { get; set; }
    }
}