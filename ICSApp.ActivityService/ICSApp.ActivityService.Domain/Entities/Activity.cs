using ICSApp.ActivityService.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ICSApp.ActivityService.Domain.Entities
{
    public partial class Activity : Notifiable, IAuditable
    {
        public Activity(string description, int idIncident, int idStatus, int idSection)
        {
            Description = description;
            IdIncident = idIncident;
            IdStatus = idStatus;
            IdSection = idSection;
            DateOpen = DateTime.Now;
            DateClosed = null;

            new AddNotifications<Activity>(this).IfNullOrEmpty(x => x.Description);
        }

        public int IdActivity { get; set; }
        public string Description { get; }
        public DateTime DateOpen { get; }
        public DateTime? DateClosed { get; set; }
        public int IdIncident { get; set; }
        public int IdStatus { get; }
        public virtual Status Status { get; set; }
        public int IdSection { get; }
        public virtual Section Section { get; set; }
        public string UsuarioInsercao { get; set; }
        public DateTime DataHoraInsercao { get; set; }
        public string UsuarioUltimaAtualizacao { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
    }
}
