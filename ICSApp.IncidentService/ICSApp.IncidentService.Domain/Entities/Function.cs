using System;
using System.Collections.Generic;
using System.Text;

namespace ICSApp.IncidentService.Domain.Entities
{
    public class Function
    {
        public Function(string name)
        {
            Name = name;
            Members = new HashSet<Member>();
        }

        public int IdFunction { get; set; }
        public string Name { get; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
