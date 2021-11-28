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
    public class TicketLogic : ITicketLogic
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketLogic(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<IEnumerable<TicketModel>> GetTickets()
        {
            return _ticketRepository.GetTickets();
        }

        public Task<TicketModel> GetTicketById(int id)
        {
            return _ticketRepository.GetTicketById(id);
        }

        public Task<TicketModel> AddTicket(TicketModel ticket)
        {
           return _ticketRepository.AddTicket(ticket);
        }

        public Task<TicketModel> UpdateTicket(TicketModel ticket)
        {
           return _ticketRepository.UpdateTicket(ticket);
        }

        public Task<TicketModel> DeleteTicket(int id)
        {
           return _ticketRepository.DeleteTicket(id);
        }

    }
}
