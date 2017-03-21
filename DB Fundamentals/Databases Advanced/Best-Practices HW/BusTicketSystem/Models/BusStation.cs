using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BusStation
    {
        public BusStation()
        {
            this.TripsArriving = new List<Trip>();
            this.TripsDeparting = new List<Trip>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Town")]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<Trip> TripsDeparting { get; set; }

        public virtual ICollection<Trip> TripsArriving { get; set; }
    }
}
