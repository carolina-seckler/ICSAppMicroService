﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Application.Interfaces
{
    public interface IUserService
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }
}
