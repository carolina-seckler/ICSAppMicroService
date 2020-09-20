using ICSApp.ActivityService.Application.Models;
using System.Collections.Generic;

namespace ICSApp.ActivityService.Application.Interfaces
{
    public interface ISectionService
    {
        public IEnumerable<SectionModel> GetAll();
        public SectionModel GetById(int id);
        public void Insert(SectionModel model);
        public void Update(SectionModel model);
        public void Delete(int id);
    }
}
