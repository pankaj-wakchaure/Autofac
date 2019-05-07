using Sample.Dal;
using System.Collections.Generic;
using UnitTestSample.Mapper;

namespace Sample.BAL
{
    public interface IEmployeeBl
    {
        IList<Models.EmployeeModel> GetAll();
        Models.EmployeeModel GetById(int Id);
        List<Models.EmployeeModel> save(Models.EmployeeModel emp);

    }
    public class EmployeeBl : IEmployeeBl
    {
        private IEmployeeDal _employeeDal;
        MappingService mappingService = new MappingService();

        public EmployeeBl(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IList<Models.EmployeeModel> GetAll()
        {
            return mappingService.Map<List<Dal.Models.EmployeeModel>, List<Models.EmployeeModel>>(_employeeDal.GetAll());
        }

        public Models.EmployeeModel GetById(int Id)
        {
            return mappingService.Map<Dal.Models.EmployeeModel, Models.EmployeeModel>(_employeeDal.GetById(Id));
        }

        public List<Models.EmployeeModel> save(Models.EmployeeModel emp)
        {
            return mappingService.Map<List<Dal.Models.EmployeeModel>, List<Models.EmployeeModel>>(
                  _employeeDal.save(mappingService.Map<Models.EmployeeModel, Dal.Models.EmployeeModel>(emp)));
        }

        public int add(int a, int b)
        {
            return a + b;
        }
        public int add(int a, int b, int c = 10)
        {
            return a + b + c;
        }
    }
}
