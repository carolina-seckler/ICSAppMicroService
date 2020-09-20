using ICSApp.ActivityService.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Infra
{
    public class UserService : IUserService
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }
}
