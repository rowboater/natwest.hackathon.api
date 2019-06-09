using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.AccessModels
{
    public class Root
    {
        public Root()
        {
            Data = new Data();
        }

        public Data Data { get; set; }
    }

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

        public string ConsentId { get; set; }

        public string CreationDateTime { get; set; }

        public string Status { get; set; }

        public string StatusUpdateDateTime { get; set; }

        public List<String> Permissions { get; set; }

        public string Risk { get; set; }

        public Links Links { get; set; }

        public Meta Meta { get; set; }
    }

    public class Links
    {
        public string Self { get; set; }
    }

    public class Meta
    {
        public string TotalPages { get; set; }
    }
}
