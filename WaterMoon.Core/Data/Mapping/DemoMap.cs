using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Model;

namespace WaterMoon.Core.Mapping
{
    public class DemoEntityMap : EntityTypeConfiguration<DemoEntity>
    {
        public DemoEntityMap()
        {
            this.ToTable("Demo");
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(400);;
        }
    }
}
