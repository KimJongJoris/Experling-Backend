using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;

namespace Logic
{
    public class EventLogic : IEventLogic
    {
        private IEventRepository _eventRepository;
        public EventLogic(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<IEnumerable<EventModel>> GetEvents()
        {
            return _eventRepository.GetEvents();
        }

        public Task<EventModel> GetEventById(int id)
        {
           return _eventRepository.GetEventById(id);
        }

        public Task<EventModel> AddEvent(EventModel Event)
        {
           return _eventRepository.AddEvent(Event);
        }

        public Task<EventModel> UpdateEvent(EventModel Event)
        {
            return _eventRepository.UpdateEvent(Event);
        }

        public Task<EventModel> DeleteEvent(int id)
        {
           return  _eventRepository.DeleteEvent(id);
        }

    }
}
