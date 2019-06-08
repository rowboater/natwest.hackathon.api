using System;

namespace Api
{
    public class Meta
    {
        public DateTime LastUpdated { get; set; }
        public int TotalResults { get; set; }
        public string Agreement { get; set; }
        public string License { get; set; }
        public string TermsOfUse { get; set; }
    }
}