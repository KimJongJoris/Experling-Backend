using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventModel>> GetEvents();
        Task<EventModel> GetEventById(int id);
        Task<EventModel> AddEvent(EventModel Event);
        Task<EventModel> UpdateEvent(EventModel Event);
        Task<EventModel> DeleteEvent(int id);
    }
}
