﻿using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class Menu
    {
        public Menu()
        {
            MenuRoleMap = new HashSet<MenuRoleMap>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public long? Parent { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<MenuRoleMap> MenuRoleMap { get; set; }
    }
}
