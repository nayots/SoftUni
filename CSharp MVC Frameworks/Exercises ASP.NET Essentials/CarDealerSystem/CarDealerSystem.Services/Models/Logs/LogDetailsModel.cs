using CarDealerSystem.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Logs
{
    public class LogDetailsModel
    {
        public string Username { get; set; }

        public LogType Operation { get; set; }

        [Display(Name = "Modified Table")]
        public string Table { get; set; }

        public DateTime Time { get; set; }
    }
}