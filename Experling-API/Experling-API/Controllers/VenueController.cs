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
    public class VenueController : ControllerBase
    {
        private readonly IVenueRepository venueRepository;

        public VenueController(IVenueRepository venueRepository)
        {
            this.venueRepository = venueRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVenues()
        {
            return Ok(await venueRepository.GetVenues());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VenueModel>> GetVenueById(int id)
        {
            var result = await venueRepository.GetVenueById(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<VenueModel>> AddVenue(VenueModel Venue)
        {
            var createdBand = await venueRepository.AddVenue(Venue);
            return CreatedAtAction(nameof(GetVenueById),
                new { id = createdBand.id }, createdBand);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<VenueModel>> UpdateVenue(int id, VenueModel venue)
        {
            if (id != venue.id)
                return BadRequest("Band Id doesn't match!");

            var bandToUpdate = await venueRepository.GetVenueById(id);

            if (bandToUpdate == null)
            {
                return NotFound();
            }

            return await venueRepository.UpdateVenue(venue);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VenueModel>> DeleteVenue(int id)
        {
            var bandToDelete = await venueRepository.GetVenueById(id);
            if (bandToDelete == null)
            {
                return NotFound();
            }

            return await venueRepository.DeleteVenue(id);
        }


    }
}
