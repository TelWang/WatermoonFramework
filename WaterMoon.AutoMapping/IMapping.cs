using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.AutoMapping
{
    public interface IMapping
    {
        To MappingTo<From, To>(From from);

        From MappingFrom<From, To>(To to);

        void CreateMap<From, To>(IManualMapper<From, To> mapper);

        void CreateMap<From, To>();
    }
}
