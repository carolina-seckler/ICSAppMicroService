using ICSApp.IncidentService.Application.Interfaces;
using ICSApp.IncidentService.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Infra
{
    public class UserService : IUserService
    {
        public Guid IdUser { get; set ; }
        public string Name { get ; set; }
    }
}
