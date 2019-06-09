using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RbsInterface.Model.AccountModels;
using RbsService;

namespace Api.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("accounts/{id}")]
        public List<Account> Get(string id)
        {
            List<Account> accounts = new List<Account>();

            INatWestService service = new NatWestService();

            service.EstablishConnection();
            service.ListAccounts(id);

            return accounts;
        }
    }
}