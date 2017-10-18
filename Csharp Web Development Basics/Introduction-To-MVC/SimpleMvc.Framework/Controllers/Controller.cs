using SimpleMvc.Framework.Interfaces;
using SimpleMvc.Framework.Interfaces.Generic;
using SimpleMvc.Framework.ViewEngine;
using SimpleMvc.Framework.ViewEngine.Generic;
using System.Runtime.CompilerServices;

namespace SimpleMvc.Framework.Controllers
{
    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string caller = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllerSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string caller = "")
        {
            string controllerName = this.GetType()
                .Name
                .Replace(MvcContext.Get.ControllerSuffix, string.Empty);

            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>(T model, string controller, string action)
        {
            string fullQualifiedName = string.Format(
                "{0}.{1}.{2}.{3}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}