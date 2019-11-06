using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class Credentials
    {
        public Credentials()
        {
            RoleMap = new HashSet<RoleMap>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }

        public virtual ICollection<RoleMap> RoleMap { get; set; }
    }
}
