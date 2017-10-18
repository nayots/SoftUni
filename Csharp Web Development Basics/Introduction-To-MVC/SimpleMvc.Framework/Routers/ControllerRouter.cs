using SimpleMvc.Framework.Attributes.Methods;
using SimpleMvc.Framework.Controllers;
using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebServer.Contracts;
using WebServer.Enums;
using WebServer.Http.Contracts;
using WebServer.Http.Response;

namespace SimpleMvc.Framework.Routers
{
    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        public IHttpResponse Handle(IHttpRequest request)
        {
            foreach (var urlParam in request.UrlParameters)
            {
                this.getParams[urlParam.Key] = urlParam.Value;
            }

            foreach (var postParam in request.FormData)
            {
                this.postParams[postParam.Key] = postParam.Value;
            }

            this.requestMethod = request.Method.ToString().ToUpper();

            var urlTokens = request.Url.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if (urlTokens.Length != 2)
            {
                return new NotFoundResponse();
            }
            if (request.Url.Contains("?"))
            {
                int ind = urlTokens[urlTokens.Length - 1].IndexOf("?");

                urlTokens[urlTokens.Length - 1] = urlTokens[urlTokens.Length - 1].Substring(0, ind);
            }

            string controllerName = urlTokens[0].Substring(0, 1).ToUpper() + urlTokens[0].Substring(1).ToLower() + MvcContext.Get.ControllerSuffix;
            string actionName = urlTokens[1].Substring(0, 1).ToUpper() + urlTokens[1].Substring(1).ToLower();

            this.controllerName = controllerName;
            this.actionName = actionName;

            MethodInfo method = this.GetMethod();

            if (method == null)
            {
                return new NotFoundResponse();
            }

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive || param.ParameterType == typeof(string))
                {
                    object value = this.getParams[param.Name];
                    this.methodParams[index] = Convert.ChangeType(value, param.ParameterType);
                    index++;
                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(
                            bindingModel, Convert.ChangeType(
                                postParams[property.Name],
                                property.PropertyType
                                )
                            );
                    }

                    this.methodParams[index] = Convert.ChangeType(
                        bindingModel,
                        bindingModelType);
                    index++;
                }
            }

            IInvocable actionResult = (IInvocable)this.GetMethod()
                .Invoke(this.GetController(), this.methodParams);

            string content = actionResult.Invoke();

            IHttpResponse response = new ContentResponse(HttpStatusCode.Ok, content);

            return response;
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in this.GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo
                    .GetCustomAttributes()
                    .Where(a => a is HttpMethodAttribute);

                if (!attributes.Any() && this.requestMethod == "GET")
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(this.requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            var controller = this.GetController();

            if (controller == null)
            {
                return new MethodInfo[0];
            }

            return this.GetController()
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllerFolder,
                this.controllerName);

            Type type = Type.GetType(controllerFullQualifiedName);

            if (type == null)
            {
                return null;
            }

            var controller = (Controller)Activator.CreateInstance(type);

            return controller;
        }
    }
}