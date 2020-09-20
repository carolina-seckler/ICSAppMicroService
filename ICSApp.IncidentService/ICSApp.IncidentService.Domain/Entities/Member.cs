using ICSApp.IncidentService.Notification;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Domain.Entities
{
    public class Member : Notifiable, IAuditable
    {
        public Member(string name, int idIncident, int idSection, int idFunction, Guid idUser)
        {
            Name = name;
            IdIncident = idIncident;
            IdSection = idSection;
            IdFunction = idFunction;
            IdUser = idUser;

            new AddNotifications<Member>(this).IfNullOrEmpty(x => x.Name);
        }

        public int IdMember { get; set; }
        public string Name { get; }
        public int IdIncident { get; }
        public virtual Incident Incident { get; set; }
        public int IdFunction { get; }
        public virtual Function Function { get; set; }
        public int IdSection { get; set; }
        public Guid IdUser { get; set; }
        public string UsuarioInsercao { get; set; }
        public DateTime DataHoraInsercao { get; set; }
        public string UsuarioUltimaAtualizacao { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}
