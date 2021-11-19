using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Data;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Experling_API.Repository
{
    public class BandRepository : IBandRepository
    {
        private readonly AppDbContext _appDbContext;

        public BandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<BandModel>> GetBands()
        {
            return await _appDbContext.Bands.ToListAsync();
        }

        public async Task<BandModel> GetBandById(int BandId)
        {
            return await _appDbContext.Bands.FirstOrDefaultAsync(e => e.id == BandId);
        }

        public async Task<BandModel> AddBand(BandModel Band)
        {
            var result = await _appDbContext.Bands.AddAsync(Band);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BandModel> UpdateBand(BandModel Band)
        {
            var result = await _appDbContext.Bands.FirstOrDefaultAsync(e => e.id == Band.id);

            if (result != null)
            {
                result.BandName = Band.BandName;
                result.Pictures = Band.Pictures;
                result.Description = Band.Description;
                result.BandPrice = Band.BandPrice;

                await _appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<BandModel> DeleteBand(int BandId)
        {
            var result = await _appDbContext.Bands.FirstOrDefaultAsync(e => e.id == BandId);
            if (result != null)
            {
                _appDbContext.Bands.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

    }
}
