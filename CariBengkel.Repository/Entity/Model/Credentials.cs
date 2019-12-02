using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class Credentials
    {
        public Credentials()
        {
            RoleMap = new HashSet<RoleMap>();
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedHost { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedHost { get; set; }
        public string VerificationCode { get; set; }
        public bool? PublicUser { get; set; }

        public virtual ICollection<RoleMap> RoleMap { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
