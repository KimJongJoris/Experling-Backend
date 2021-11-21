using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace Experling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetEvents()
        {
            return Ok(await eventRepository.GetEvents());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EventModel>> GetCustomerById(int id)
        {
            var result = await eventRepository.GetEventById(id);

            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<EventModel>> CreateEvent(EventModel Event)
        {
            var createdEvent = await eventRepository.AddEvent(Event);

            return CreatedAtAction(nameof(GetEvents),
                new {id = createdEvent.id}, createdEvent);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EventModel>> UpdateEvent(int id, EventModel Event)
        {
            if (id != Event.id)
                return BadRequest("Customer Id doesn't match!");

            var customerToUpdate = await eventRepository.GetEventById(id);

            if (customerToUpdate == null)
                return NotFound();

            return await eventRepository.UpdateEvent(Event);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EventModel>> DeleteEvent(int id)
        {
            var customerToDelete = await eventRepository.GetEventById(id);
            if (customerToDelete == null)
            {
                return NotFound();
            }

            return await eventRepository.DeleteEvent(id);
        }

    }
}
