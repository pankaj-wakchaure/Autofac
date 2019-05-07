using Autofac;
using Sample.BAL;
using Sample.Dal;
using System.Web.Http;
using Autofac.Integration.WebApi;
using UnitTestSample.Mapper;
using System.Reflection;
using System.Configuration;

namespace UnitTestSample.App_Start
{
    public static class AutofacWebApiConfig
    {
        private static IContainer _container;
        
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterService(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        public static IContainer RegisterService(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
             
            builder.RegisterType<EmployeeBl>().As<IEmployeeBl>().InstancePerRequest();
            builder.RegisterType<EmployeeDal>().As<IEmployeeDal>().InstancePerRequest();
           
            builder.RegisterType<EmployeeMappingProfile>().As<EmployeeMappingProfile>().InstancePerRequest();

            string connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

            //register DataAccessModule
            builder.RegisterModule(new DataAccessModule
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString,
                // RepositoryType = ConfigurationManager.AppSettings["RepositoryType"].ToString()
            });
            
            _container = builder.Build();

            return _container;
        }
    }
    public class DataAccessModule : Autofac.Module
    {
        public string ConnectionString { get; set; }
        //public string RepositoryType { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeDal>().As<IEmployeeDal>()
                .WithParameter("connectionString", ConnectionString).InstancePerRequest();
            
            /* This will be when we have multiple environment*/
            //switch (RepositoryType)
            //{
            //    case "ADO":
            //        builder.RegisterType<EmployeeDal>().As<IEmployeeDal>().WithParameter("connectionString", ConnectionString).InstancePerRequest();
            //        break;
            //}

        }
    }
}