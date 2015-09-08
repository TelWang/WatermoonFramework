using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Data;

namespace WaterMoon.Core.Events
{
    public class EntityDeleted<T> where T : BaseEntity
    {
        public EntityDeleted(T entity)
        {
            this.Entity = entity;
        }

        public T Entity { get; private set; }
    }
}
