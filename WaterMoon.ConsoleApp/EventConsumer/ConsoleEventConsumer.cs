using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterMoon.Core.Events;
using WaterMoon.Core.Model;
using WaterMoon.Services.Event;

namespace WaterMoon.ConsoleApp
{
    public class ConsoleEventConsumer : IConsumer<EntityInserted<DemoEntity>>,
        IConsumer<EntityUpdated<DemoEntity>>,
        IConsumer<EntityDeleted<DemoEntity>>
    {

        public void HandleEvent(EntityInserted<DemoEntity> eventMessage)
        {
            Console.WriteLine("插入数据Demo:" + eventMessage.Entity.Name);
        }

        public void HandleEvent(EntityUpdated<DemoEntity> eventMessage)
        {
            throw new NotImplementedException();
        }

        public void HandleEvent(EntityDeleted<DemoEntity> eventMessage)
        {
            throw new NotImplementedException();
        }
    }
}
