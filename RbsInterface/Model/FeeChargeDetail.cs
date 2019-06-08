using System.Collections.Generic;

namespace Api
{
    public class FeeChargeDetail
    {
        public string FeeCategory { get; set; }
        public string FeeType { get; set; }
        public List<string> Notes { get; set; }
        public string FeeAmount { get; set; }
        public string ApplicationFrequency { get; set; }
        public string CalculationFrequency { get; set; }
        public OtherFeeType OtherFeeType { get; set; }
    }
}