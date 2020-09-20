using ICSApp.ActivityService.Application.Interfaces;
using ICSApp.ActivityService.Application.Models;
using ICSApp.ActivityService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ICSApp.ActivityService.Application.Services
{
    public class SectionService : ISectionService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public SectionService(IRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            Section obj = repository.Select<Section>(id);
            repository.Delete(obj);
            unitOfWork.Commit();
        }

        public IEnumerable<SectionModel> GetAll()
        {
            var all = repository.Query<Section>().ToList();

            return all.Select(obj => new SectionModel
            {
                IdSection = obj.IdSection,
                Name = obj.Name
            });
        }

        public SectionModel GetById(int id)
        {
            var obj = repository.Query<Section>().Where(x => x.IdSection == id).FirstOrDefault();

            return obj == null ? null : (new SectionModel
            {
                IdSection = obj.IdSection,
                Name = obj.Name
            });
        }

        public void Insert(SectionModel model)
        {
            Section obj = new Section(model.Name);

            repository.Insert(obj);
            unitOfWork.Commit();
        }

        public void Update(SectionModel model)
        {
            Section obj = new Section(model.Name);

            obj.IdSection = model.IdSection;
            repository.Update(obj);
            unitOfWork.Commit();
        }
    }
}
