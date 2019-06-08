using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface.Model
{
    public class AuthorisatonRequest
    {
        public string grant_type => "client_credentials";

        public string client_id => "NOwU7XoB_j1J7JUK6B6jm6d8ufHX78UKAeD23lawR00=";

        public string client_secret => "tTDtUt7b-ntp7bXm0Il_seml5Lh1gwo9sS-1RzWP56s=";

        public string scope => "accounts";
    }
}
