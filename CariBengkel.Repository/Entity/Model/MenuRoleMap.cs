using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class MenuRoleMap
    {
        public long Id { get; set; }
        public long IdMenu { get; set; }
        public long IdRole { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
