using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Events;
using WaterMoon.Core.Model;

namespace WaterMoon.Services.Event
{
    public class ModelCacheEventConsumer : IConsumer<EntityInserted<DemoEntity>>,
        IConsumer<EntityUpdated<DemoEntity>>,
        IConsumer<EntityDeleted<DemoEntity>>
    {
        public void HandleEvent(EntityInserted<DemoEntity> eventMessage)
        { 
            
        }

        public void HandleEvent(EntityUpdated<DemoEntity> eventMessage)
        {

        }

        public void HandleEvent(EntityDeleted<DemoEntity> eventMessage)
        {

        }
    }
}
