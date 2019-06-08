using System.Collections.Generic;

namespace Api
{
    public class FeeChargeCap
    {
        public string MinMaxType { get; set; }
        public string FeeCapAmount { get; set; }
        public List<string> FeeType { get; set; }
        public string CappingPeriod { get; set; }
    }
}