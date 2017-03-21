using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public Status Status { get; set; }

        [InverseProperty("TripsDeparting")]
        public virtual BusStation OriginStation { get; set; }


        [InverseProperty("TripsArriving")]
        public virtual BusStation DestinationStation { get; set; }

        [ForeignKey("BusCompany")]
        public int BusCompanyId { get; set; }

        public virtual BusCompany BusCompany { get; set; }
    }
}
