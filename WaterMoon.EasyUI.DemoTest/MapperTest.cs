using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.AutoMapping;

namespace WaterMoon.EasyUI.DemoTest
{
    public class MapperTest
    {
        public static void Mapper()
        {
            DefualtMapping maping = new DefualtMapping();
            maping.CreateMap<From, To>();
            maping.CreateMap<FromFrom, ToTo>(new MapperA());

            From f1 = new From() { MyProperty1 = 1, MyProperty2 = "a" };

            To t2 = new To() { MyProperty1 = 2, MyProperty2 = "B" };

            To t1 = maping.MappingTo<From, To>(f1);

            From f2 = maping.MappingFrom<From, To>(t2);

            FromFrom ff1 = new FromFrom() { MyProperty1 = 11, MyProperty2 = "a1" };

            ToTo tt1 = maping.MappingTo<FromFrom, ToTo>(ff1);
        }
    }

    public class From
    {
        public int MyProperty1 { get; set; }

        public string MyProperty2 { get; set; }
    }

    public class To
    {
        public int MyProperty1 { get; set; }

        public string MyProperty2 { get; set; }
    }

    public class FromFrom
    {
        public int MyProperty1 { get; set; }

        public string MyProperty2 { get; set; }
    }

    public class ToTo
    {
        public int MyProperty1 { get; set; }

        public string MyProperty2 { get; set; }
    }

    public class MapperA : IManualMapper<FromFrom, ToTo>
    {

        public ToTo MappingTo(FromFrom from)
        {
            return new ToTo()
            {
                MyProperty1 = from.MyProperty1,
                MyProperty2 = from.MyProperty2
            };
        }

        public FromFrom MappingFrom(ToTo to)
        {
            return new FromFrom()
            {
                MyProperty1 = to.MyProperty1,
                MyProperty2 = to.MyProperty2
            };
        }

        public void MapperRegist()
        {

        }
    }
}
