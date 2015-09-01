using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.AutoMapping
{
    public class DefualtMapper<T1, T2> : IManualMapper<T1, T2>
    {
        public T2 MappingTo(T1 from)
        {
            return Mapper.Map<T1, T2>(from);
        }

        public T1 MappingFrom(T2 to)
        {
            return Mapper.Map<T2, T1>(to);
        }


        public void MapperRegist()
        {
            Mapper.CreateMap<T1, T2>();
            Mapper.CreateMap<T2, T1>();
        }
    }
}
