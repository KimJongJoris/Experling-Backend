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
    public class BandLogic : IBandLogic
    {
        private IBandRepository _bandRepository;

        public BandLogic(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        public Task<IEnumerable<BandModel>> getAllBands()
        {
            return _bandRepository.GetBands();
        }

        public Task<BandModel> GetBandById(int BandId)
        {
            return _bandRepository.GetBandById(BandId);
        }

        public Task<BandModel> AddBand(BandModel Band)
        {
            return _bandRepository.AddBand(Band);
        }

        public Task<BandModel> UpdateBand(BandModel Band)
        {
            return _bandRepository.UpdateBand(Band);
        }

        public Task<BandModel> DeleteBand(int Bandid)
        {
            return _bandRepository.DeleteBand(Bandid);
        }

    }
}
