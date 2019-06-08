using System.Collections.Generic;

namespace Api
{
    public class BCA
    {
        public string Name { get; set; }
        public string Identification { get; set; }
        public bool OnSaleIndicator { get; set; }
        public List<BCAMarketingState> BCAMarketingState { get; set; }
        public List<string> Segment { get; set; }
    }    
}