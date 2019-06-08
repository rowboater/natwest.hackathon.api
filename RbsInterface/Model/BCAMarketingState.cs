using System.Collections.Generic;

namespace Api
{
    public class BCAMarketingState
    {
        public string Identification { get; set; }
        public List<string> Notes { get; set; }
        public string FirstMarketedDate { get; set; }
        public string LastMarketedDate { get; set; }
        public CoreProduct CoreProduct { get; set; }
        public FeaturesAndBenefits FeaturesAndBenefits { get; set; }
        public Eligibility Eligibility { get; set; }
        public string MarketingState { get; set; }
        public string StateTenurePeriod { get; set; }
        public int StateTenureLength { get; set; }
        public List<OtherFeesCharge> OtherFeesCharges { get; set; }
        public string PredecessorID { get; set; }
    }
}