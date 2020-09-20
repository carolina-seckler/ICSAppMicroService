using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using ICSApp.IncidentService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System;
using ICSApp.IncidentService.Notification;

namespace ICSApp.IncidentService.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public IncidentService(IRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            Incident obj = repository.Select<Incident>(id);
            repository.Delete(obj);
            unitOfWork.Commit();
        }

        public IEnumerable<IncidentModel> GetAll()
        {
            var all = repository.Query<Incident>().ToList();

            return all.Select(obj => new IncidentModel
            {
                IdIncident = obj.IdIncident,
                Name = obj.Name,
                IncidentDate = obj.IncidentDate
            });
        }

        public IncidentModel GetById(int id)
        {
            var obj = repository.Query<Incident>().Where(x => x.IdIncident == id).FirstOrDefault();

            return obj == null? null :(new IncidentModel
            {
                IdIncident = obj.IdIncident,
                Name = obj.Name,
                IncidentDate = obj.IncidentDate
            });
        }

        public IReadOnlyCollection<Notification.Notification> Insert(IncidentModel model)
        {
            Incident obj = new Incident(model.Name, model.IncidentDate);

            if (obj.Notifications.Count() > 0)
            {
                return obj.Notifications;
            }
            repository.Insert(obj);
            unitOfWork.Commit();
            return null;
        }

        public IReadOnlyCollection<Notification.Notification> Update(IncidentModel model)
        {
            Incident obj = new Incident(model.Name, model.IncidentDate);
            if (obj.Notifications.Count() > 0)
            {
                return obj.Notifications;
            }
            obj.IdIncident = model.IdIncident;
            repository.Update(obj);
            unitOfWork.Commit();
            return null;
        }
    }
}
