using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Data;
using WaterMoon.Core.Model;
using WaterMoon.EasyUI.Core.Infrastructure;


namespace WaterMoon.EasyUI.DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineContext.Initialize(true);
            var testMenuRepository = (IRepository<TestMenu>)EngineContext.Current.Resolve(typeof(IRepository<TestMenu>));
            testMenuRepository.Insert(new TestMenu() { Name="开源" });
            MapperTest.Mapper();
        }
    }
}
