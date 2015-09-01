using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.EasyUI.Core.Configuration;
using WaterMoon.EasyUI.Core.Infrastructure.DependencyManagement;

namespace WaterMoon.EasyUI.Core.Infrastructure
{
    public class WaterMoonEngine : IEngine
    {
        private ContainerManager _containerManager;

        #region Ctor

        public WaterMoonEngine()
            : this(new ContainerConfigurer())
        {
        }

        public WaterMoonEngine(WaterMoonConfig config)
        {
            var configurer = new ContainerConfigurer();
            InitializeContainer(configurer, config);
        }

        public WaterMoonEngine(ContainerConfigurer configurer)
        {
            var config = ConfigurationManager.GetSection("WaterMoonConfig") as WaterMoonConfig;
            InitializeContainer(configurer, config);
        }

        public WaterMoonEngine(ContainerConfigurer configurer,WaterMoonConfig config)
        {
            InitializeContainer(configurer, config);
        }
        
        #endregion


        #region Utilities

        private void RunStartupTasks()
        {
            var typeFinder = _containerManager.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = new List<IStartupTask>();
            foreach (var startUpTaskType in startUpTaskTypes)
            {
                startUpTasks.Add((IStartupTask)Activator.CreateInstance(startUpTaskType));
            }
            //sort
            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
            {
                startUpTask.Execute();
            }
        }

        private void InitializeContainer(ContainerConfigurer configurer, WaterMoonConfig config)
        {
            var builder = new ContainerBuilder();

            _containerManager = new ContainerManager(builder.Build());
            configurer.Configure(this, _containerManager, config);
        }

        #endregion

        #region Methods

        public void Initialize(WaterMoonConfig config)
        {
            //startup tasks
            if (!config.IgnoreStartupTasks)
            {
                RunStartupTasks();
            }
        }

        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }

        #endregion

        #region Properties

        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        #endregion
    }
}
