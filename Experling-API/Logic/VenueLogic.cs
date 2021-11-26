using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces.Data;
using Common.Interfaces.Logic;
using Common.Models;

namespace Logic
{
    public class VenueLogic : IVenueLogic
    {
        private IVenueRepository _venueRepository;

        public VenueLogic(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }

        public Task<IEnumerable<VenueModel>> GetVenues()
        {
            return _venueRepository.GetVenues();
        }

        public Task<VenueModel> GetVenueById(int id)
        {
            return _venueRepository.GetVenueById(id);
        }

        public Task<VenueModel> AddVenue(VenueModel venue)
        {
            return _venueRepository.AddVenue(venue);
        }

        public Task<VenueModel> UpdateVenue(VenueModel venue)
        {
            return _venueRepository.UpdateVenue(venue);
        }

        public Task<VenueModel> DeleteVenue(int id)
        { 
            return _venueRepository.DeleteVenue(id);
        }
    }
}
