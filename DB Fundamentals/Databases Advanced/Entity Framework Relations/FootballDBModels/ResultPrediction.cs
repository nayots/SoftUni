using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballDBModels
{
    public enum Prediction
    {
        [Description("Home Team Win")]
        home,
        [Description("Away Team Win")]
        away,
        [Description("Draw game")]
        draw,
    }
    public class ResultPrediction
    {
        [Key]
        public int Id { get; set; }

        public virtual Prediction Prediction { get; set; }
    }
}
