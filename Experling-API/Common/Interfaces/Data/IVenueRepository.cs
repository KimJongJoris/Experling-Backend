using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Data
{
    public interface IVenueRepository
    {
        Task<IEnumerable<VenueModel>> GetVenues();
        Task<VenueModel> GetVenueById(int id);
        Task<VenueModel> AddVenue(VenueModel Venue);
        Task<VenueModel> UpdateVenue(VenueModel Venue);
        Task<VenueModel> DeleteVenue(int id);
    }
}
