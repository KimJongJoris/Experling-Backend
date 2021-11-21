using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
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
