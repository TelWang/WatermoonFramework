using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WaterMoon.Core.Infrastructure.DependencyManagement
{
    public class AutofacRequestLifetimeHttpModule : IHttpModule
    {
        public static readonly object HttpRequestTag = "AutofacWebRequest";

        public void Init(HttpApplication context)
        {
            context.EndRequest += ContextEndRequest;
        }

        public static ILifetimeScope GetLifetimeScope(ILifetimeScope container, Action<ContainerBuilder> configurationAction)
        {
            if (HttpContext.Current != null)
            {
                return LifetimeScope ?? (LifetimeScope = InitializeLifetimeScope(configurationAction, container));
            }
            else
            {
                return InitializeLifetimeScope(configurationAction, container);
            }
        }

        public void Dispose()
        {
        }

        static ILifetimeScope LifetimeScope
        {
            get
            {
                return (ILifetimeScope)HttpContext.Current.Items[typeof(ILifetimeScope)];
            }
            set
            {
                HttpContext.Current.Items[typeof(ILifetimeScope)] = value;
            }
        }

        public static void ContextEndRequest(object sender, EventArgs e)
        {
            ILifetimeScope lifetimeScope = LifetimeScope;
            if (lifetimeScope != null)
                lifetimeScope.Dispose();
        }

        static ILifetimeScope InitializeLifetimeScope(Action<ContainerBuilder> configurationAction, ILifetimeScope container)
        {
            return (configurationAction == null)
                ? container.BeginLifetimeScope(HttpRequestTag)
                : container.BeginLifetimeScope(HttpRequestTag, configurationAction);
        }
    }
}
