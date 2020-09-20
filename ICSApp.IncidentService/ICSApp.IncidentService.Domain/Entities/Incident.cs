using ICSApp.IncidentService.Notification;
using System;
using System.Collections.Generic;

namespace ICSApp.IncidentService.Domain.Entities
{
    public class Incident : Notifiable, IAuditable
    {
        public Incident(string name, DateTime incidentDate)
        {
            Name = name;
            IncidentDate = incidentDate;
            Members = new HashSet<Member>();

            new AddNotifications<Incident>(this).IfNullOrEmpty(x => x.Name);
        }

        public int IdIncident { get; set; }
        public string Name { get; }
        public DateTime IncidentDate { get; }
        public virtual ICollection<Member> Members { get; set; }
        public string UsuarioInsercao { get; set; }
        public DateTime DataHoraInsercao { get; set; }
        public string UsuarioUltimaAtualizacao { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}
