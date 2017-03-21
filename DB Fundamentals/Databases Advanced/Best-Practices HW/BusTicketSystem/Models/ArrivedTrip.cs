using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ArrivedTrip
    {
        [Key]
        public int Id { get; set; }

        public DateTime ActualArrivalTime { get; set; }

        public virtual BusStation OriginStation { get; set; }

        public virtual BusStation DestinationStation { get; set; }

        public int PassengerCount { get; set; }
    }
}
