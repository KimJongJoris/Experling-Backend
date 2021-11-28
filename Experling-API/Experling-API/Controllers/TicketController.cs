using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Logic;
using Common.Models;


namespace Experling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketLogic _ticketLogic;

        public TicketController(ITicketLogic ticketLogic)
        {
            _ticketLogic = ticketLogic;
        }

        [HttpGet]
        public async Task<ActionResult> GetTickets()
        {
            return Ok(await _ticketLogic.GetTickets());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TicketModel>> GetTicketById(int id)
        {
            var result = await _ticketLogic.GetTicketById(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<TicketModel>> AddTicket(TicketModel Ticket)
        {
            var createdBand = await _ticketLogic.AddTicket(Ticket);
            return CreatedAtAction(nameof(GetTicketById),
                new { id = createdBand.id }, createdBand);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TicketModel>> UpdateBand(int id, TicketModel ticket)
        {
            if (id != ticket.id)
                return BadRequest("Band Id doesn't match!");

            var bandToUpdate = await _ticketLogic.GetTicketById(id);

            if (bandToUpdate == null)
            {
                return NotFound();
            }

            return await _ticketLogic.UpdateTicket(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<TicketModel>> DeleteTicket(int id)
        {
            var bandToDelete = await _ticketLogic.GetTicketById(id);
            if (bandToDelete == null)
            {
                return NotFound();
            }

            return await _ticketLogic.DeleteTicket(id);
        }


    }
}
