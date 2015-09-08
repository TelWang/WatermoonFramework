using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Infrastructure;

namespace WaterMoon.Services.Event
{
    public class EventPublisher : IEventPublisher
    {
        private readonly ISubscriptionService _subscriptionService;

        public EventPublisher(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        protected virtual void PublishToConsumer<T>(IConsumer<T> x, T eventMessage)
        {
            try
            {
                x.HandleEvent(eventMessage);
            }
            catch (Exception exc)
            {
                //var logger = EngineContext.Current.Resolve<ILogger>();
                //try
                //{
                //    logger.Error(exc.Message, exc);
                //}
                //catch (Exception)
                //{

                //}
            }
        }

        public virtual void Publish<T>(T eventMessage)
        {
            var subscriptions = _subscriptionService.GetSubscriptions<T>();
            subscriptions.ToList().ForEach(x => PublishToConsumer(x, eventMessage));
        }
    }
}
