using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Experling_API.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<EventModel>> GetEvents()
        {
            return await _appDbContext.Events.ToListAsync();
        }

        public async Task<EventModel> GetEventById(int EventId)
        {
            return await _appDbContext.Events.FirstOrDefaultAsync(e => e.id == EventId);
        }

        public async Task<EventModel> AddEvent(EventModel Event)
        {
            var result = await _appDbContext.Events.AddAsync(Event);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<EventModel> UpdateEvent(EventModel Event)
        {
            var result = await _appDbContext.Events.FirstOrDefaultAsync(e => e.id == Event.id);
            if (result != null)
            {
                result.Description = Event.Description;
                result.Bandid = Event.Bandid;
                result.EventName = Event.EventName;
                result.EventPrice = Event.EventPrice;
                result.AvailableTickets = Event.AvailableTickets;
                result.EventStartTime = Event.EventStartTime;
                result.EventEndTime = Event.EventEndTime;
                result.EventLocation = Event.EventLocation;
                result.Venueid = Event.Venueid;

                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<EventModel> DeleteEvent(int EventId)
        {
            var result = await _appDbContext.Events.FirstOrDefaultAsync(e => e.id == EventId);
            if (result != null)
            {
                 _appDbContext.Events.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;

        }
    }
}
