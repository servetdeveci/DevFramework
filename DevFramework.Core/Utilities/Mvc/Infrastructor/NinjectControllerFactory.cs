using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;

namespace DevFramework.Core.Utilities.Mvc.Infrastructor
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory(params INinjectModule [] module)
        {
            _kernel = new StandardKernel(module);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
        
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    } 
}
