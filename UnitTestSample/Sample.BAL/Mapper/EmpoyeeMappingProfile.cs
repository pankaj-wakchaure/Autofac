using AutoMapper;

namespace UnitTestSample.Mapper
{
    public class EmployeeMappingProfile: Profile
    {
        protected override void Configure()
        {
            CreateMap<Sample.BAL.Models.EmployeeModel, Sample.Dal.Models.EmployeeModel>();
            CreateMap<Sample.Dal.Models.EmployeeModel, Sample.BAL.Models.EmployeeModel>();
        }
    }
}