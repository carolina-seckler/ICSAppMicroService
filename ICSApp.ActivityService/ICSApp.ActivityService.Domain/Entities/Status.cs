using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.ActivityService.Domain.Entities
{
    public partial class Status
    {
        public Status(string name) 
        {
            Name = name;
            Activities = new HashSet<Activity>();
        }

        public int IdStatus { get; set; }
        public string Name { get; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
