using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETMS.Services;
using ETMS.Models;
namespace ETMS.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/

        private  SupplierRepository sRepo;        
        public SupplierController()
        {
            this.sRepo = new SupplierRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewSuppliers()
        {
            IEnumerable<Supplier> c = sRepo.AllSuppliers();
            return View(c);
        }
        public ActionResult ViewSupplier(int id=0)
        {
            Supplier s = sRepo.getSupplier(id);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);            
        }

        [HttpPost]
        public ActionResult UpdateSupplierInfo(Supplier s)
        {
            if (ModelState.IsValid)
            {
                sRepo.UpdateSupplier(s);
            }
            return RedirectToAction("ViewSuppliers");
        }

        public ActionResult UpdateSupplierInfo(int id = 0)
        {
            Supplier c = sRepo.getSupplier(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }

        [HttpPost, ActionName("DeleteSupplier")]
        public ActionResult DeleteS()
        {
            int Id = Convert.ToInt32(Request["SId"]);
            Supplier supp = sRepo.getSupplier(Id);
            sRepo.DeleteSupplier(supp);
            return RedirectToAction("ViewSuppliers");
        }

        [HttpGet]
        public ActionResult DeleteSupplier(int id = 0)
        {
            Supplier p = sRepo.getSupplier(id);
            return View(p);
        }

        public ActionResult AddSupplierInfo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplierInfo(Supplier e)
        {
            sRepo.saveSupplier(e);
            return RedirectToAction("ViewSuppliers");
        }
    }
}
