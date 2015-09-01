using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Events;
using WaterMoon.Core.Model;

namespace WaterMoon.Services.Event
{
    public class ModelCacheEventConsumer : IConsumer<EntityInserted<TestMenu>>,
        IConsumer<EntityUpdated<TestMenu>>,
        IConsumer<EntityDeleted<TestMenu>>
    {
        public void HandleEvent(EntityInserted<TestMenu> eventMessage)
        { 
        
        }

        public void HandleEvent(EntityUpdated<TestMenu> eventMessage)
        {

        }

        public void HandleEvent(EntityDeleted<TestMenu> eventMessage)
        {

        }
    }
}
