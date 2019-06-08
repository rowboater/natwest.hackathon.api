using System.Collections.Generic;

namespace Api
{
    public class FeaturesAndBenefits
    {
        public List<FeatureBenefitItem> FeatureBenefitItem { get; set; }
        public List<MobileWallet> MobileWallet { get; set; }
        public List<Card> Card { get; set; }
    }
}