using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Configuration;
using WaterMoon.Core.Infrastructure.DependencyManagement;

namespace WaterMoon.Core.Infrastructure
{
    public interface IEngine
    {
        ContainerManager ContainerManager { get; }

        void Initialize(WaterMoonConfig config);

        T Resolve<T>() where T : class;

        object Resolve(Type type);

        T[] ResolveAll<T>();
    }
}
