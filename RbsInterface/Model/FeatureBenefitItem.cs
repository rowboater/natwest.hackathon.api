namespace Api
{
    public class FeatureBenefitItem
    {
        public string Identification { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public OtherType OtherType { get; set; }
        public string Textual { get; set; }
        public bool? Indicator { get; set; }
    }
}