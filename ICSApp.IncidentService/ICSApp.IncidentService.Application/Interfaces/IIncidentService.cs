using ICSApp.IncidentService.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSApp.IncidentService.Application.Interfaces
{
    public interface IIncidentService
    {
        public IEnumerable<IncidentModel> GetAll();
        public IncidentModel GetById(int id);
        public IReadOnlyCollection<Notification.Notification> Insert(IncidentModel model);
        public IReadOnlyCollection<Notification.Notification> Update(IncidentModel model);
        public void Delete(int id);
    }
}
