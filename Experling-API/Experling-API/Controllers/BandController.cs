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
    public class BandController : ControllerBase
    {
        private readonly IBandRepository bandRepository;

        public BandController(IBandRepository bandRepository)
        {
            this.bandRepository = bandRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBands()
        {
            return Ok(await bandRepository.GetBands());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BandModel>> GetBandById(int id)
        {
            var result = await bandRepository.GetBandById(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<BandModel>> AddBand(BandModel Band)
        {
            var createdBand = await bandRepository.AddBand(Band);
            return CreatedAtAction(nameof(GetBandById),
                new{id = createdBand.id}, createdBand);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BandModel>> UpdateBand(int id, BandModel band)
        {
            if (id != band.id)
                return BadRequest("Band Id doesn't match!");

            var bandToUpdate = await bandRepository.GetBandById(id);

            if (bandToUpdate == null)
            {
                return NotFound();
            }

            return await bandRepository.UpdateBand(band);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BandModel>> DeleteBand(int id)
        {
            var bandToDelete = await bandRepository.GetBandById(id);
            if (bandToDelete == null)
            {
                return NotFound();
            }

            return await bandRepository.DeleteBand(id);
        }

        
    }
    
}
