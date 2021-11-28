using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Logic
{
    public interface ITicketLogic
    {
        public Task<IEnumerable<TicketModel>> GetTickets();
        public Task<TicketModel> GetTicketById(int id);
        public Task<TicketModel> AddTicket(TicketModel ticket);
        public Task<TicketModel> UpdateTicket(TicketModel ticket);
        public Task<TicketModel> DeleteTicket(int id);

    }
}
