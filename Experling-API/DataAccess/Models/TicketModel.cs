using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class TicketModel 
    {
        public int id { get; set; }
        public int Customerid { get; set; }
        public int Eventid { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public byte AgeCheck { get; set; }
        public string GUid { get; set; }
    }
}
