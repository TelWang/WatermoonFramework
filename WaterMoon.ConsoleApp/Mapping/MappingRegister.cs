using System;
using WaterMoon.AutoMapping;
using WaterMoon.Core.Model;
using WaterMoon.Core.Infrastructure;
using WaterMoon.Model;

namespace WaterMoon.ConsoleApp
{
    public class MappingRegister
    {
        static MappingRegister()
        {
            IDependencyResolver resolver = Singleton<IDependencyResolver>.Instance;
            Singleton<IMapping>.Instance = (IMapping)resolver.GetService(typeof(IMapping));
        }

        public static void Mapper<From, To>()
        {
            Singleton<IMapping>.Instance.CreateMap<From, To>();
        }

        public static void Mapper<From, To>(IManualMapper<From, To> mapper)
        {
            Singleton<IMapping>.Instance.CreateMap<From, To>(mapper);
        }

        public static void RegisterAll() 
        {
            MappingRegister.Mapper<Demo, DemoEntity>(new DemoToDemoEntityMapping());
        }
    }
}
