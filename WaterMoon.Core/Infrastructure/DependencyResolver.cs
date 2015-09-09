using System;
using System.Collections.Generic;

namespace WaterMoon.Core.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            return EngineContext.Current.ContainerManager.ResolveOptional(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)EngineContext.Current.Resolve(type);
        }
    }

    public static class DependencyResolverExtensions
    {
        public static T GetService<T>(this IDependencyResolver provider)
        {
            return (T)provider.GetService(typeof(T));
        }

        public static object GetRequiredService(this IDependencyResolver provider, Type serviceType)
        {
            var service = provider.GetService(serviceType);
            return service;
        }

        public static T GetRequiredService<T>(this IDependencyResolver provider)
        {
            return (T)provider.GetRequiredService(typeof(T));
        }

        public static IEnumerable<T> GetServices<T>(this IDependencyResolver provider)
        {
            return provider.GetRequiredService<IEnumerable<T>>();
        }

        public static IEnumerable<object> GetServices(this IDependencyResolver provider, Type serviceType)
        {
            var genericEnumerable = typeof(IEnumerable<>).MakeGenericType(serviceType);
            return (IEnumerable<object>)provider.GetRequiredService(genericEnumerable);
        }
    }
}
