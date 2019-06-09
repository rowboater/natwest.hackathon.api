using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RbsInterface.AccessModels;

namespace RbsService.Data
{
    public class ConsentRepository : IConsentRepository
    {
        public Root Get(string document)
        {
            if (String.IsNullOrEmpty(document))
                return null;
            var result = JsonConvert.DeserializeObject<Root>(document);
            return result;
        }
    }
}
