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
    public class VenueController : ControllerBase
    {
        private readonly IVenueLogic venueLogic;

        public VenueController(IVenueLogic venueRepository)
        {
            this.venueLogic = venueRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVenues()
        {
            return Ok(await venueLogic.GetVenues());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VenueModel>> GetVenueById(int id)
        {
            var result = await venueLogic.GetVenueById(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<VenueModel>> AddVenue(VenueModel Venue)
        {
            var createdBand = await venueLogic.AddVenue(Venue);
            return CreatedAtAction(nameof(GetVenueById),
                new { id = createdBand.id }, createdBand);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VenueModel>> UpdateVenue(int id, VenueModel venue)
        {
            if (id != venue.id)
                return BadRequest("Band Id doesn't match!");

            var bandToUpdate = await venueLogic.GetVenueById(id);

            if (bandToUpdate == null)
            {
                return NotFound();
            }

            return await venueLogic.UpdateVenue(venue);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VenueModel>> DeleteVenue(int id)
        {
            var bandToDelete = await venueLogic.GetVenueById(id);
            if (bandToDelete == null)
            {
                return NotFound();
            }

            return await venueLogic.DeleteVenue(id);
        }


    }
}
