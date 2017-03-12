using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public enum CompType
    {
        local,
        national,
        international
    }
    public class CompetitionType
    {
        [Key]
        public int Id { get; set; }

        public virtual CompType CompType { get; set; }
    }
}
