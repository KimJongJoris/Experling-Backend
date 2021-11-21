using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class EventModel
    {
        public int id { get; set; }
        public int Venueid { get; set; }
        public int Bandid { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public decimal EventPrice { get; set; }
        public DateTime EventStartTime { get;set;}
        public DateTime EventEndTime { get; set; }
        public string EventLocation { get; set; }
        public int AvailableTickets { get; set; }
    }
}
