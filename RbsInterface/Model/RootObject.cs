using System.Collections.Generic;

namespace Api
{
    public class RootObject
    {
        public Meta meta { get; set; }
        public List<Datum> data { get; set; }
    }
}