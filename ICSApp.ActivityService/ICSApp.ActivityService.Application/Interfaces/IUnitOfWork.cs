using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Application.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
