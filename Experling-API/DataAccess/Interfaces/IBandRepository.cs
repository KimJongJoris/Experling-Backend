using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IBandRepository
    {
        Task<IEnumerable<BandModel>> GetBands();
        Task<BandModel> GetBandById(int id);
        Task<BandModel> AddBand(BandModel Band);
        Task<BandModel> UpdateBand(BandModel Band);
        Task<BandModel> DeleteBand(int id);

    }
}
