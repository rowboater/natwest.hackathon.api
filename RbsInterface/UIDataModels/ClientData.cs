using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.UIDataModels
{
    public class ClientData
    {
        public string accountName { get; set; }
        public List<TransactionData> TransactionDatas { get; set; }
    }
}
