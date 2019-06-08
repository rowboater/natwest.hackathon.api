using System.Collections.Generic;

namespace Api
{
    public class Card
    {
        public List<string> Scheme { get; set; }
        public string Type { get; set; }
        public bool ContactlessIndicator { get; set; }
    }
}