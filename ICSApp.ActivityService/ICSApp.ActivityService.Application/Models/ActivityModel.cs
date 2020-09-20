using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Application.Models
{
    public class ActivityModel
    {
        public int IdActivity { get; set; }
        public string Description { get; set; }
        public DateTime DateOpen { get; set; }
        public DateTime? DateClosed { get; set; }
        public int IdIncident { get; set; }
        public int IdStatus { get; set; }
        public int IdSection { get; set; }
    }
}
