using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETMS.Services;
using ETMS.Models;

namespace ETMS.Controllers
{
    public class GetSuppliersController : ApiController
    {
        private SupplierRepository sRepo;        
        public GetSuppliersController()
        {
            this.sRepo = new SupplierRepository();
        }

        public IEnumerable<Supplier> GetS()
        {
            return sRepo.AllSuppliers();
        }       
    }
}
