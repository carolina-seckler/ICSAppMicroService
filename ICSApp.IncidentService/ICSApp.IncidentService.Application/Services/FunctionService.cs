using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using ICSApp.IncidentService.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ICSApp.IncidentService.Application.Services
{
    public class FunctionService : IFunctionService
    {
        private readonly IRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public FunctionService(IRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Delete(int id)
        {
            Function obj = repository.Select<Function>(id);
            repository.Delete(obj);
            unitOfWork.Commit();
        }

        public IEnumerable<FunctionModel> GetAll()
        {
            var all = repository.Query<Function>().ToList();

            return all.Select(obj => new FunctionModel
            {
                IdFunction = obj.IdFunction,
                Name = obj.Name
            });
        }

        public FunctionModel GetById(int id)
        {
            var obj = repository.Query<Function>().Where(x => x.IdFunction == id).FirstOrDefault();

            return obj == null ? null : (new FunctionModel
            {
                IdFunction = obj.IdFunction,
                Name = obj.Name
            });
        }

        public void Insert(FunctionModel model)
        {
            Function obj = new Function(model.Name);

            repository.Insert(obj);
            unitOfWork.Commit();
        }

        public void Update(FunctionModel model)
        {
            Function obj = new Function(model.Name);

            obj.IdFunction = model.IdFunction;
            repository.Update(obj);
            unitOfWork.Commit();
        }
    }
}
