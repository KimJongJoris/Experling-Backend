using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Experling_API.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TicketModel>> GetTickets()
        {
            return await _appDbContext.Tickets.ToListAsync();
        }

        public async Task<TicketModel> GetTicketById(int TicketId)
        {
            return await _appDbContext.Tickets.FirstOrDefaultAsync(e => e.id == TicketId);
        }

        public async Task<TicketModel> AddTicket(TicketModel Ticket)
        {
            var result = _appDbContext.Tickets.Add(Ticket);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<TicketModel> UpdateTicket(TicketModel Ticket)
        {
            var result = await _appDbContext.Tickets.FirstOrDefaultAsync(e => e.id == Ticket.id);
            if (result != null)
            {
                result.CustomerName = Ticket.CustomerName;
                result.CustomerEmail = Ticket.CustomerEmail;
                result.AgeCheck = Ticket.AgeCheck;
                result.Eventid = Ticket.Eventid;
                result.Customerid = Ticket.Eventid;

                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
            
        }

        public async Task<TicketModel> DeleteTicket(int TicketId)
        {
            var result = await _appDbContext.Tickets.FirstOrDefaultAsync(e => e.id == TicketId);
            if (result != null)
            {
                _appDbContext.Tickets.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
