using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETMS.Services;
using ETMS.Models;
namespace ETMS.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        private EmployeeRepository eRepo;        
        public EmployeeController()
        {
            this.eRepo = new EmployeeRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewEmployees()
        {
            IEnumerable<Employee> e = eRepo.AllEmployees();
            return View(e);
        }

        public ActionResult ViewEmployee(int id=0)
        {
            Employee e = eRepo.getEmployee(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);            
        }

        [HttpPost]
        public ActionResult UpdateEmployeeInfo(Employee e)
        {
            if (ModelState.IsValid)
            {
                eRepo.UpdateEmployee(e);
            }
            return RedirectToAction("ViewEmployees");            
        }

        public ActionResult UpdateEmployeeInfo(int id=0)
        {
            Employee e = eRepo.getEmployee(id);
            if (e == null)
            {
                return HttpNotFound();
            }
            return View(e);
        }

        [HttpPost, ActionName("DeleteEmployee")]
        public ActionResult DeleteE()
        {
            int Id = Convert.ToInt32(Request["empID"]);
            Employee emp = eRepo.getEmployee(Id);
            eRepo.DeleteEmployee(emp);
            return RedirectToAction("ViewEmployees");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int id=0)
        {
            Employee e = eRepo.getEmployee(id);
            return View(e);
        }

        [HttpPost]
        public ActionResult AddEmployeeInfo(Employee e)
        {               
            eRepo.saveEmployee(e);
            return RedirectToAction("ViewEmployees");
        }

        public ActionResult AddEmployeeInfo()
        {         
            return View();
        }
             
        public void InsertCall(string no, string type, string duration, string datetime)
        {
            eRepo.SaveCallData(no,type,duration,datetime);
        }

        public void InsertSMS(string no, string type,string datetime)
        {
            eRepo.SaveSMSData(no, type,datetime);
        }
    }
}
