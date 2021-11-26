using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Models;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly AppDbContext _appDbContext;

        public VenueRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<VenueModel>> GetVenues()
        {
            return await _appDbContext.Venues.ToListAsync();
        }

        public async Task<VenueModel> GetVenueById(int VenueId)
        {
            return await _appDbContext.Venues.FirstOrDefaultAsync(e => e.id == VenueId);
        }

        public async Task<VenueModel> AddVenue(VenueModel Venue)
        {
            var result = await _appDbContext.Venues.AddAsync(Venue);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<VenueModel> UpdateVenue(VenueModel Venue)
        {
            var result = await GetVenueById(Venue.id);
            if (result != null)
            {
                result.VenueName = Venue.VenueName;
                result.VenueLocation = Venue.VenueLocation;
                result.Description = Venue.Description;
                result.Pictures = Venue.Pictures;

                await _appDbContext.SaveChangesAsync();

                return result;
            }
            return null;
        }

        public async Task<VenueModel> DeleteVenue(int id )
        {
            var result = await _appDbContext.Venues.FirstOrDefaultAsync(e => e.id == id);
            if (result != null)
            {
                _appDbContext.Venues.Remove(result);
                await _appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

    }
}
