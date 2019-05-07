using Sample.BAL;
using Sample.BAL.Models;
using System.Collections.Generic;
using System.Threading;
using System.Web.Http;

namespace UnitTestSample.Controllers
{
    public class EmployeeController : ApiController
    {
        string _connectionString;
        private readonly IEmployeeBl _employeeBl;
        public EmployeeController(IEmployeeBl employeeBl)
        {
            _employeeBl = employeeBl;
        }
         
        public EmployeeController(string   connectionString)
        {
            _connectionString = connectionString;
        }
        // GET api/<controller>
        [BasicAuthentication]
        public IList<EmployeeModel> Get()
        {
            string userName = Thread.CurrentPrincipal.Identity.Name;

            return _employeeBl.GetAll();
        }
        
        // GET api/<controller>
        [HttpGet]
        public EmployeeModel Get(string id)
        {

            return _employeeBl.GetById(10);
        }
        [HttpPost]
        public List<EmployeeModel> Post(EmployeeModel employee)
        {
            return _employeeBl.save(employee);
        }
    }
}