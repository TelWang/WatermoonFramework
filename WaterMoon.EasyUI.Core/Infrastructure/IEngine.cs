using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.EasyUI.Core.Configuration;
using WaterMoon.EasyUI.Core.Infrastructure.DependencyManagement;

namespace WaterMoon.EasyUI.Core.Infrastructure
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
