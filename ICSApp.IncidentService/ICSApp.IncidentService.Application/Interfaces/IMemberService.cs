using ICSApp.IncidentService.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Application.Interfaces
{
    public interface IMemberService
    {
        public IEnumerable<MemberModel> GetAll();
        public MemberModel GetById(int id);
        public IReadOnlyCollection<Notification.Notification> Insert(MemberModel model);
        public IReadOnlyCollection<Notification.Notification> Update(MemberModel model);
        public void Delete(int id);
        public IEnumerable<MemberModel> GetByIncident(int id);
    }
}
