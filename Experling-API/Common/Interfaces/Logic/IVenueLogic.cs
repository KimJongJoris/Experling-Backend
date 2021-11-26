using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Models;

namespace Common.Interfaces.Logic
{
    public interface IVenueLogic
    {
        public Task<IEnumerable<VenueModel>> GetVenues();
        public Task<VenueModel> GetVenueById(int id);
        public Task<VenueModel> AddVenue(VenueModel venue);
        public Task<VenueModel> UpdateVenue(VenueModel venue);
        public Task<VenueModel> DeleteVenue(int id);

    }
}
