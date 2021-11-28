using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Logic
{
    public interface IEventLogic
    {
        public Task<IEnumerable<EventModel>> GetEvents();
        public Task<EventModel> GetEventById(int id);
        public Task<EventModel> AddEvent(EventModel Event);
        public Task<EventModel> UpdateEvent(EventModel Event);
        public Task<EventModel> DeleteEvent(int id);
    }
}
