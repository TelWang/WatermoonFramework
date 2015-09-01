using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.AutoMapping;
using WaterMoon.Core.Data;
using WaterMoon.Core.Paged;
using WaterMoon.EasyUI.Core;
using WaterMoon.EasyUI.Core.Infrastructure.DependencyManagement;
using WaterMoon.Services.Event;

namespace WaterMoon.EasyUI.DemoTest
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            string collectionString = "Data Source=.;Initial Catalog=demo;User ID=sa;Password=sa;Trusted_Connection=False;";
            builder.Register<IDbContext>(c => new WaterMoonContext(collectionString)).PerLifeStyle(ComponentLifeStyle.LifetimeScope);
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).PerLifeStyle(ComponentLifeStyle.LifetimeScope);
            builder.RegisterGeneric(typeof(PagedList<>)).As(typeof(IPagedList<>)).PerLifeStyle(ComponentLifeStyle.LifetimeScope);


            builder.RegisterType<DefualtMapping>().As<IMapping>().SingleInstance();

            //注册所有实现IConsumer<>类型的对象
            var consumers = typeFinder.FindClassesOfType(typeof(IConsumer<>)).ToList();
            foreach (var consumer in consumers)
            {
                builder.RegisterType(consumer)
                    .As(consumer.FindInterfaces((type, criteria) =>
                    {
                        var isMatch = type.IsGenericType && ((Type)criteria).IsAssignableFrom(type.GetGenericTypeDefinition());
                        return isMatch;
                    }, typeof(IConsumer<>)))
                    .PerLifeStyle(ComponentLifeStyle.LifetimeScope);
            }
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();
            builder.RegisterType<SubscriptionService>().As<ISubscriptionService>().SingleInstance();
        }


        public int Order
        {
            get { return 1; }
        }
    }
}
