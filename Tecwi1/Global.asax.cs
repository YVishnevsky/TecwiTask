using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using AutoMapper;
using Tecwi1.Models;
using Autofac;
using System.Reflection;
using Autofac.Integration.WebApi;
using Tecwi1.Repositories;
using Autofac.Integration.Mvc;
using Tecwi1.Dtos;

namespace Tecwi1
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>()
                .ReverseMap();
            });

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<TecwiDbContext>();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>();
           
            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}