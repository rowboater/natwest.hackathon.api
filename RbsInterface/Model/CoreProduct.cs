using System.Collections.Generic;

namespace Api
{
    public class CoreProduct
    {
        public string ProductDescription { get; set; }
        public string ProductURL { get; set; }
        public string TcsAndCsURL { get; set; }
        public List<string> SalesAccessChannels { get; set; }
        public List<string> ServicingAccessChannels { get; set; }
    }
}