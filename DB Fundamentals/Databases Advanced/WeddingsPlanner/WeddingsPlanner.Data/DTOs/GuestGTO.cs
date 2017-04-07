using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingsPlanner.Models.enums;

namespace WeddingsPlanner.Data.DTOs
{
    public class GuestGTO
    {
        public string Name { get; set; }
        public bool RSVP { get; set; }
        public Family Family { get; set; }
    }
}
