using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class RoleMap
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long CredentialId { get; set; }

        public virtual Credentials Credential { get; set; }
        public virtual Role Role { get; set; }
    }
}
