using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Application.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
