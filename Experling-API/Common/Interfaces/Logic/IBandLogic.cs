using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;

namespace Common.Interfaces.Logic
{
    public interface IBandLogic
    {
        public Task<IEnumerable<BandModel>> getAllBands();
        public Task<BandModel> GetBandById(int BandId);
        public Task<BandModel> AddBand(BandModel Band);
        public Task<BandModel> UpdateBand(BandModel Band);
        public Task<BandModel> DeleteBand(int Bandid);

    }
}
