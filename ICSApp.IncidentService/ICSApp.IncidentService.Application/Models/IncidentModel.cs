using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Application.Models
{
    public class IncidentModel
    {
        public int IdIncident { get; set; }
        public string Name { get; set; }
        public DateTime IncidentDate { get; set; }
    }
}
