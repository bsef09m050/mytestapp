using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETMS.Models;
using ETMS.Services;
namespace ETMS.Controllers
{
    public class GetClientsController : ApiController
    {
        private ClientRepository eRepo;        
        public GetClientsController()
        {
            this.eRepo = new ClientRepository();
        }

        public IEnumerable<Client> GetC()
        {
            return eRepo.AllClients();
        }        
    }
}
