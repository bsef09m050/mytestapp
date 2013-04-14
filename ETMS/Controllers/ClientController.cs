using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETMS.Services;
using ETMS.Models;
namespace ETMS.Controllers
{
    public class ClientController : Controller
    {
        //
        // GET: /Client/
        private ClientRepository cRepo;        
        public ClientController()
        {
            this.cRepo = new ClientRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewClients()
        {
            IEnumerable<Client> c = cRepo.AllClients();
            return View(c);
        }
        public ActionResult ViewClient(int id=0)
        {
            Client c = cRepo.getClient(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);            
        }
        [HttpPost]
        public ActionResult UpdateClientInfo(Client c)
        {
            if (ModelState.IsValid)
            {
                cRepo.UpdateClient(c);
            }
            return RedirectToAction("ViewClients");            
        }

        public ActionResult UpdateClientInfo(int id = 0)
        {
            Client c = cRepo.getClient(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        [HttpPost, ActionName("DeleteClient")]
        public ActionResult DeleteC()
        {
            int Id = Convert.ToInt32(Request["CId"]);
            Client client = cRepo.getClient(Id);
            cRepo.DeleteCleint(client);
            return RedirectToAction("ViewClients");
        }

        [HttpGet]
        public ActionResult DeleteClient(int id = 0)
        {
            Client e = cRepo.getClient(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult AddClientInfo(Client e)
        {
            cRepo.saveClient(e);
            return RedirectToAction("ViewClients");
        }

        public ActionResult AddClientInfo()
        {
            return View();
        } 

    }
}
