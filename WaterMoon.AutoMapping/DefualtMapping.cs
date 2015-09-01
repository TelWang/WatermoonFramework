using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.AutoMapping
{
    public class DefualtMapping : IMapping
    {
        Dictionary<KeyValuePair<Type, Type>, object> innerMapper = new Dictionary<KeyValuePair<Type, Type>, object>();

        public To MappingTo<From, To>(From from)
        {
            KeyValuePair<Type, Type> registType = new KeyValuePair<Type, Type>(typeof(From), typeof(To));
            object mapper;
            if (innerMapper.TryGetValue(registType, out mapper))
            {
                if (mapper is IManualMapper<From, To>)
                {
                    return ((IManualMapper<From, To>)mapper).MappingTo(from);
                }
            }
            return default(To);
        }

        public From MappingFrom<From, To>(To to)
        {
            KeyValuePair<Type, Type> registType = new KeyValuePair<Type, Type>(typeof(From), typeof(To));
            object mapper;
            if (innerMapper.TryGetValue(registType, out mapper))
            {
                if (mapper is IManualMapper<From, To>)
                {
                    return ((IManualMapper<From, To>)mapper).MappingFrom(to);
                }
            }
            return default(From);
        }

        public void CreateMap<From, To>(IManualMapper<From, To> mapper)
        {
            KeyValuePair<Type, Type> registType = new KeyValuePair<Type, Type>(typeof(From), typeof(To));

            mapper.MapperRegist();

            if (innerMapper.ContainsKey(registType))
            {
                innerMapper[registType] = mapper;
            }
            else
            {
                innerMapper.Add(registType, mapper);
            }
        }

        public void CreateMap<From, To>()
        {
            CreateMap<From, To>(new DefualtMapper<From, To>());
        }
    }
}
