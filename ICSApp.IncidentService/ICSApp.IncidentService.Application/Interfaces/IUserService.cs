using ICSApp.IncidentService.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Application.Interfaces
{
    public interface IUserService
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }
}
