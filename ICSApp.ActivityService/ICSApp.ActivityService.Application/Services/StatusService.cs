using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Application.Models;
using ICSApp.ActivityService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ICSApp.ActivityService.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public StatusService(IRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            Status obj = repository.Select<Status>(id);
            repository.Delete(obj);
            unitOfWork.Commit();
        }

        public IEnumerable<StatusModel> GetAll()
        {
            var all = repository.Query<Status>().ToList();

            return all.Select(obj => new StatusModel
            {
                IdStatus = obj.IdStatus,
                Name = obj.Name
            });
        }

        public StatusModel GetById(int id)
        {
            var obj = repository.Query<Status>().Where(x => x.IdStatus == id).FirstOrDefault();

            return obj == null ? null : (new StatusModel
            {
                IdStatus = obj.IdStatus,
                Name = obj.Name
            });
        }

        public void Insert(StatusModel model)
        {
            Status obj = new Status(model.Name);

            repository.Insert(obj);
            unitOfWork.Commit();
        }

        public void Update(StatusModel model)
        {
            Status obj = new Status(model.Name);

            obj.IdStatus = model.IdStatus;
            repository.Update(obj);
            unitOfWork.Commit();
        }
    }
}
