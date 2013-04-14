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
    public class GetEmployeesController : ApiController
    {
        //
        // GET: /Employee/
        private EmployeeRepository eRepo;        
        public GetEmployeesController()
        {
            this.eRepo = new EmployeeRepository();
        }

        public IEnumerable<Employee> GetEmp()
        {
            return eRepo.AllEmployees();
        }
        public List<Employee> GetMatchedEmp(string name)
        {
            return eRepo.getMatchedEmployees(name);
        }  
    }
}
