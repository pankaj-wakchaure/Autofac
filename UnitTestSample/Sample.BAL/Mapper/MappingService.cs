using System;

namespace UnitTestSample.Mapper
{
    public interface IMappingService
    {
        TDest Map<TSrc, TDest>(TSrc src);
        void AssertConfigurationIsValid();
    }

    public class MappingService : IMappingService
    {
        public void AssertConfigurationIsValid()
        {
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }

        public TDest Map<TSrc, TDest>(TSrc src)
        {
            return AutoMapper.Mapper.Map<TSrc, TDest>(src);
        }

        public MappingService()
        {
            AutoMapper.Mapper.Initialize(cnf =>
            cnf.AddProfile<EmployeeMappingProfile>()
            );
        }
    }
}