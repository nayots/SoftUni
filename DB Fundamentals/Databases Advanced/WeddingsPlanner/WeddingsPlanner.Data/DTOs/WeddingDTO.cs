using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingsPlanner.Models;

namespace WeddingsPlanner.Data.DTOs
{
    public class WeddingDTO
    {
        public string Bride { get; set; }
        public string Bridegroom { get; set; }
        public DateTime? Date { get; set; }
        public string Agency { get; set; }
        public List<GuestGTO> Guests { get; set; }
    }
}
