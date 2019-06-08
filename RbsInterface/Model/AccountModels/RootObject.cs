using System.Collections.Generic;
using RbsInterface.Model.AccountModels;

namespace Api
{
    public class RootObject
    {
        public Data Data { get; set; }
        public Links Links { get; set; }
        public Meta Meta { get; set; }
    }
}