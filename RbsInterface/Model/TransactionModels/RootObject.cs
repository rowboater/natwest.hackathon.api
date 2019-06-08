using System.Collections.Generic;

namespace RbsInterface.Model.TransactionModels
{
    public class RootObject
    {
        public Data Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }
}