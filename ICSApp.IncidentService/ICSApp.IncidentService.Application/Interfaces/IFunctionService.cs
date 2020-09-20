using ICSApp.IncidentService.Application.Models;
using System.Collections.Generic;

namespace ICSApp.IncidentService.Application.Interfaces
{
    public interface IFunctionService
    {
        public IEnumerable<FunctionModel> GetAll();
        public FunctionModel GetById(int id);
        public void Insert(FunctionModel model);
        public void Update(FunctionModel model);
        public void Delete(int id);
    }
}
