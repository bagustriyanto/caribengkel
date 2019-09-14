using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class Role
    {
        public Role()
        {
            RoleMap = new HashSet<RoleMap>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<RoleMap> RoleMap { get; set; }
    }
}
