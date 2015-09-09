using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.AutoMapping;
using WaterMoon.Core.Model;
using WaterMoon.Model;

namespace WaterMoon.AutoMapping
{
    public class DemoToDemoEntityMapping : IManualMapper<Demo, DemoEntity>
    {

        public DemoEntity MappingTo(Demo from)
        {
            return new DemoEntity() { Name = from.Name.ToString() };
        }

        public Demo MappingFrom(DemoEntity to)
        {
            throw new NotImplementedException();
        }

        public void MapperRegist()
        {

        }
    }
}
