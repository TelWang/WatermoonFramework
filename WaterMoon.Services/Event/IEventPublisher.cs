using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.Services.Event
{
    public interface IEventPublisher
    {
        void Publish<T>(T eventMessage);
    }
}
