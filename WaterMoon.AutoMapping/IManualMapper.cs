using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.AutoMapping
{
    public interface IManualMapper<T1, T2> 
    {
        T2 MappingTo(T1 from);

        T1 MappingFrom(T2 to);

        void MapperRegist();
    }
}
