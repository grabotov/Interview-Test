using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using InterviewTestTemplatev2.Services;
using System.Web.Mvc;

namespace InterviewTestTemplatev2.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureIocUnityContainer()
        {
            IUnityContainer container = new UnityContainer();

            RegisterServices(container);

            DependencyResolver.SetResolver(new DInjector(container));
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<ICalculationService, CalculationService>();
            container.RegisterType<IHrEmployeeRepo, HrEmployeeRepo>();

        }
    }
}