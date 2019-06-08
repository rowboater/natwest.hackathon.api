using System;
using System.Collections.Generic;
using System.Text;

namespace RbsInterface
{
    public class NatWestService
    {
        

        public bool GetAccessToken()
        {
            OpenAPIRequestor _apiRequestor = new OpenAPIRequestor(true);
            var response = _apiRequestor.PostDataAsync("token");

            return true;
        }

        public void GetAccountInformation()
        {

        }

    }
}
