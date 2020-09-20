using ICSApp.ActivityService.Application.Models;
using System.Collections.Generic;

namespace ICSApp.ActivityService.Application.Interfaces
{
    public interface IActivityService
    {
        public IEnumerable<ActivityModel> GetAll();
        public ActivityModel GetById(int id);
        public IReadOnlyCollection<Notification.Notification> Insert(ActivityModel model);
        public IReadOnlyCollection<Notification.Notification> Update(ActivityModel model);
        public void Delete(int id);
        public IEnumerable<ActivityModel> GetByIncident(int id);
        public IEnumerable<ActivityModel> FilterBySection(IEnumerable<ActivityModel> col, int id);
        public IEnumerable<ActivityModel> FilterByStatus(IEnumerable<ActivityModel> col, int id);
        public void CloseActivity(int id);
    }
}
