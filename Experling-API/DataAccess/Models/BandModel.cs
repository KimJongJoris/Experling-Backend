using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class BandModel
    {
        public int id { get; set; }
        public string Pictures { get; set; }
        public string BandName { get; set; }
        public string Description { get; set; }
        public decimal BandPrice { get; set; }
    }
}
