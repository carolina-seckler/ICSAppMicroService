using System;

namespace ICSApp.IncidentService.Application.Interfaces
{
    public interface IUserProfile
    {
        public Guid IdUser { get; set; }
        public string Name { get; set; }
    }
}
