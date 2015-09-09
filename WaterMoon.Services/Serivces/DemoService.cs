using WaterMoon.AutoMapping;
using WaterMoon.Core.Data;
using WaterMoon.Core.Model;
using WaterMoon.Model;
using WaterMoon.Services.Event;
using WaterMoon.Services.IServices;

namespace WaterMoon.Services.Serivces
{
    public class DemoService : IDemoService
    {
        private readonly IRepository<DemoEntity> _demoRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapping _mapping;

        public DemoService(IRepository<DemoEntity> demoRepository,
            IEventPublisher eventPublisher,IMapping mapping) 
        {
            _demoRepository = demoRepository;
            _eventPublisher = eventPublisher;
            _mapping = mapping;
        }

        public void Insert(Demo demo) 
        {
            var demoentity = _mapping.MappingTo<Demo, DemoEntity>(demo);
            _demoRepository.Insert(demoentity);
            _eventPublisher.EntityInserted(demoentity);
        }
    }
}
