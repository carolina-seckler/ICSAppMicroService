using ICSApp.ActivityService.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Application.Interfaces
{
    public interface IStatusService
    {
        public IEnumerable<StatusModel> GetAll();
        public StatusModel GetById(int id);
        public void Insert(StatusModel model);
        public void Update(StatusModel model);
        public void Delete(int id);
    }
}
