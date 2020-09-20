using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using ICSApp.IncidentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSApp.IncidentService.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public MemberService(IRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            Member obj = repository.Select<Member>(id);
            repository.Delete(obj);
            unitOfWork.Commit();
        }

        public IEnumerable<MemberModel> GetAll()
        {
            var all = repository.Query<Member>().ToList();

            return all.Select(obj => new MemberModel
            {
                IdMember = obj.IdMember,
                Name = obj.Name,
                IdIncident = obj.IdIncident,
                IdSection = obj.IdSection,
                IdFunction = obj.IdFunction,
                IdUser = obj.IdUser
            });
        }

        public MemberModel GetById(int id)
        {
            var obj = repository.Query<Member>().Where(x => x.IdMember == id).FirstOrDefault();

            return obj == null ? null : (new MemberModel
            {
                IdMember = obj.IdMember,
                Name = obj.Name,
                IdIncident = obj.IdIncident,
                IdSection = obj.IdSection,
                IdFunction = obj.IdFunction,
                IdUser = obj.IdUser
            });
        }

        public IReadOnlyCollection<Notification.Notification> Insert(MemberModel model)
        {
            Member obj = new Member(model.Name, model.IdIncident, model.IdSection, model.IdFunction, model.IdUser);

            if (obj.Notifications.Count() > 0)
            {
                return obj.Notifications;
            }
            repository.Insert(obj);
            unitOfWork.Commit();
            return null;
        }

        public IReadOnlyCollection<Notification.Notification> Update(MemberModel model)
        {
            Member obj = new Member(model.Name, model.IdIncident, model.IdSection, model.IdFunction, model.IdUser);
            if (obj.Notifications.Count() > 0)
            {
                return obj.Notifications;
            }
            obj.IdMember = model.IdMember;
            repository.Update(obj);
            unitOfWork.Commit();
            return null;
        }

        public IEnumerable<MemberModel> GetByIncident(int id)
        {
            var all = repository.Query<Member>().Where(x => x.IdIncident == id);

            return all.Select(obj => new MemberModel
            {
                IdMember = obj.IdMember,
                Name = obj.Name,
                IdIncident = obj.IdIncident,
                IdSection = obj.IdSection,
                IdUser = obj.IdUser
            });
        }
    }
}
