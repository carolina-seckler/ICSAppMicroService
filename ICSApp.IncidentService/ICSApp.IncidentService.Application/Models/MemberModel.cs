using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Application.Models
{
    public class MemberModel
    {
        public int IdMember { get; set; }
        public string Name { get; set; }
        public int IdIncident { get; set; }
        public int IdFunction { get; set; }
        public int IdSection { get; set; }
        public int IdUser { get; set; }
    }
}
