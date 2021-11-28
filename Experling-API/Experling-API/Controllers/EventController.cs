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

    public class EventController : ControllerBase
    {
        private readonly IEventLogic _eventLogic;

        public EventController(IEventLogic eventLogic)
        {
            _eventLogic = eventLogic;
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            return Ok(await _eventLogic.GetEvents());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventModel>> GetCustomerById(int id)
        {
            var result = await _eventLogic.GetEventById(id);

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> CreateEvent(EventModel Event)
        {
            var createdEvent = await _eventLogic.AddEvent(Event);

            return CreatedAtAction(nameof(GetEvents),
                new {id = createdEvent.id}, createdEvent);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EventModel>> UpdateEvent(int id, EventModel Event)
        {
            if (id != Event.id)
                return BadRequest("Customer Id doesn't match!");

            var customerToUpdate = await _eventLogic.GetEventById(id);

            if (customerToUpdate == null)
                return NotFound();

            return await _eventLogic.UpdateEvent(Event);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EventModel>> DeleteEvent(int id)
        {
            var customerToDelete = await _eventLogic.GetEventById(id);
            if (customerToDelete == null)
            {
                return NotFound();
            }

            return await _eventLogic.DeleteEvent(id);
        }

    }
}
