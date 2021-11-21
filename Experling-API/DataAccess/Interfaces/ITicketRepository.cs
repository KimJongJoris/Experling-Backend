﻿using System;
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
        Task<TicketModel> GetTicketById(int id);
        Task<TicketModel> AddTicket(TicketModel Ticket);
        Task<TicketModel> UpdateTicket(TicketModel Ticket);
        Task<TicketModel> DeleteTicket(int id);
    }
}
