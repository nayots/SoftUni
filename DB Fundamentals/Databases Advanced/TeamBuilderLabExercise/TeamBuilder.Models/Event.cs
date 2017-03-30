using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Event
    {
        public Event()
        {
            this.ParticipatingTeams = new List<Team>();
        }
        private DateTime endDate;
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{DD/MM/YYYY HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                if (this.StartDate > value && this.StartDate != null)
                {
                    throw new ArgumentException("EndDate must be after the start date");
                }

                endDate = value;
            }
        }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<Team> ParticipatingTeams { get; set; }
    }
}
