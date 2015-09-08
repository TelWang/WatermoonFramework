using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Configuration;
using WaterMoon.Core.Infrastructure.DependencyManagement;

namespace WaterMoon.Core.Infrastructure
{
    public class ContainerConfigurer
    {
        public virtual void Configure(IEngine engine, ContainerManager containerManager, WaterMoonConfig configuration)
        {
            //other dependencies
            containerManager.AddComponentInstance<WaterMoonConfig>(configuration, "watermoon.configuration");
            containerManager.AddComponentInstance<IEngine>(engine, "watermoon.engine");
            containerManager.AddComponentInstance<ContainerConfigurer>(this, "watermoon.containerConfigurer");

            //type finder
            containerManager.AddComponent<ITypeFinder, WebAppTypeFinder>("watermoon.typeFinder");

            //register dependencies provided by other assemblies
            var typeFinder = containerManager.Resolve<ITypeFinder>();
            containerManager.UpdateContainer(x =>
            {
                var drTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
                var drInstances = new List<IDependencyRegistrar>();
                foreach (var drType in drTypes)
                    drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
                //sort
                drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
                foreach (var dependencyRegistrar in drInstances)
                {
                    dependencyRegistrar.Register(x, typeFinder);
                }
            });
        }
    }
}
