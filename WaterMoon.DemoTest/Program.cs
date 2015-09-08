using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.AutoMapping;
using WaterMoon.Core.Data;
using WaterMoon.Core.Model;
using WaterMoon.Core.Infrastructure;
using WaterMoon.Services.IServices;
using WaterMoon.Model;


namespace WaterMoon.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineContext.Initialize(true);
            MappingRegister.RegisterAll();

            IDependencyResolver resolver = Singleton<IDependencyResolver>.Instance;
            IDemoService demoService = resolver.GetService<IDemoService>();
            IMapping mapper = resolver.GetService<IMapping>();


            demoService.Insert(new Demo() {  Name="123" });

            Console.ReadLine();
        }
    }
}
