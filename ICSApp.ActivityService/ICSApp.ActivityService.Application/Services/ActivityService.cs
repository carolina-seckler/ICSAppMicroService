using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Application.Models;
using ICSApp.ActivityService.Domain.Entities;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;

namespace ICSApp.ActivityService.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ActivityService(IRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            Activity obj = repository.Select<Activity>(id);
            repository.Delete(obj);
            unitOfWork.Commit();
        }

        public IEnumerable<ActivityModel> GetAll()
        {
            var all = repository.Query<Activity>().ToList();

            return all.Select(obj => new ActivityModel
            {
                IdActivity = obj.IdActivity,
                Description = obj.Description,
                DateOpen = obj.DateOpen,
                DateClosed = obj.DateClosed,
                IdIncident = obj.IdIncident,
                IdSection = obj.IdSection,
                IdStatus = obj.IdStatus
            });
        }

        public ActivityModel GetById(int id)
        {
            var obj = repository.Query<Activity>().Where(x => x.IdActivity == id).FirstOrDefault();

            return obj == null ? null : (new ActivityModel
            {
                IdActivity = obj.IdActivity,
                Description = obj.Description,
                DateOpen = obj.DateOpen,
                DateClosed = obj.DateClosed,
                IdIncident = obj.IdIncident,
                IdSection = obj.IdSection,
                IdStatus = obj.IdStatus
            });
        }

        public IReadOnlyCollection<Notification.Notification> Insert(ActivityModel model)
        {
            Activity obj = new Activity(model.Description, model.IdIncident, model.IdStatus, model.IdSection);

            if (obj.Notifications.Count() > 0)
            {
                return obj.Notifications;
            }
            repository.Insert(obj);
            unitOfWork.Commit();
            return null;
        }

        public IReadOnlyCollection<Notification.Notification> Update(ActivityModel model)
        {
            Activity obj = new Activity(model.Description, model.IdIncident, model.IdStatus, model.IdSection);
            if (obj.Notifications.Count() > 0)
            {
                return obj.Notifications;
            }
            obj.IdActivity = model.IdActivity;
            repository.Update(obj);
            unitOfWork.Commit();
            return null;
        }

        public IEnumerable<ActivityModel> GetByIncident(int id)
        {
            var all = repository.Query<Activity>().Where(x => x.IdIncident == id);

            return all.Select(obj => new ActivityModel
            {
                IdActivity = obj.IdActivity,
                Description = obj.Description,
                DateOpen = obj.DateOpen,
                DateClosed = obj.DateClosed,
                IdIncident = obj.IdIncident,
                IdSection = obj.IdSection,
                IdStatus = obj.IdStatus
            });
        }

        public IEnumerable<ActivityModel> FilterBySection(IEnumerable<ActivityModel> col, int id)
        {
            return col.Where(x => x.IdSection == id);
        }

        public IEnumerable<ActivityModel> FilterByStatus(IEnumerable<ActivityModel> col, int id)
        {
            return col.Where(x => x.IdStatus == id);
        }

        public void CloseActivity(int id)
        {
            var obj = repository.Query<Activity>().Where(x => x.IdActivity == id).FirstOrDefault();

            if (obj != null)
            {
                obj.DateClosed = DateAndTime.Now;
                repository.Update(obj);
                unitOfWork.Commit();
            }
        }
    }
}
