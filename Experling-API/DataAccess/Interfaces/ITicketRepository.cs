using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<TicketModel>> GetTickets();
        Task<TicketModel> GetTicketById();
        Task<TicketModel> AddTicket();
        Task<TicketModel> UpdateTicket();
        Task<TicketModel> DeleteTicket();
    }
}
