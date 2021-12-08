using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;

namespace Experling_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandLogic _bandLogic;

        public BandController(IBandLogic bandLogic)
        {
            _bandLogic = bandLogic;
        }

        [HttpGet]
        public async Task<ActionResult> GetBands()
        {
             return Ok(await _bandLogic.getAllBands());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BandModel>> GetBandById(int id)
        {
            var result = await _bandLogic.GetBandById(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<BandModel>> AddBand(BandModel Band)
        {
            var createdBand = await _bandLogic.AddBand(Band);
            return CreatedAtAction(nameof(GetBandById),
                new{id = createdBand.id}, createdBand);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<BandModel>> UpdateBand(int id, BandModel band)
        {
            if (id != band.id)
                return BadRequest("Band Id doesn't match!");

            var bandToUpdate = await _bandLogic.GetBandById(id);

            if (bandToUpdate == null)
            {
                return NotFound();
            }

            return await _bandLogic.UpdateBand(band);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BandModel>> DeleteBand(int id)
        {
            var bandToDelete = await _bandLogic.GetBandById(id);
            if (bandToDelete == null)
            {
                return NotFound();
            }

            return await _bandLogic.DeleteBand(id);
        }


        
    }
    
}
