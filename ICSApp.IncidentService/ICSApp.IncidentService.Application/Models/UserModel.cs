using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Application.Models
{
    public class UserModel
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }

    public class UserLoginModel 
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
