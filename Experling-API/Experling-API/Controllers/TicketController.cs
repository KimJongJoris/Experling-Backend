using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces;


namespace Experling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetTickets()
        {
            return Ok(await ticketRepository.GetTickets());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TicketModel>> GetTicketById(int id)
        {
            var result = await ticketRepository.GetTicketById(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<TicketModel>> AddTicket(TicketModel Ticket)
        {
            var createdBand = await ticketRepository.AddTicket(Ticket);
            return CreatedAtAction(nameof(GetTicketById),
                new { id = createdBand.id }, createdBand);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TicketModel>> UpdateBand(int id, TicketModel ticket)
        {
            if (id != ticket.id)
                return BadRequest("Band Id doesn't match!");

            var bandToUpdate = await ticketRepository.GetTicketById(id);

            if (bandToUpdate == null)
            {
                return NotFound();
            }

            return await ticketRepository.UpdateTicket(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TicketModel>> DeleteTicket(int id)
        {
            var bandToDelete = await ticketRepository.GetTicketById(id);
            if (bandToDelete == null)
            {
                return NotFound();
            }

            return await ticketRepository.DeleteTicket(id);
        }


    }
}
