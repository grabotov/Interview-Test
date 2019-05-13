using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace InterviewTestTemplatev2.Services
{
    public class DInjector : IDependencyResolver
    {
        private IUnityContainer _unityContainer;
        public DInjector(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }
        public object GetService(Type serviceType)
        {
            try
            {

                return _unityContainer.Resolve(serviceType);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {

                return _unityContainer.ResolveAll(serviceType);
            }
            catch (Exception ex)
            {
                return new List<object>();
            }
        }
    }
}