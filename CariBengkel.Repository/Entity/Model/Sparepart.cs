﻿using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class Sparepart
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public long IdStore { get; set; }
        public long IdVehicleType { get; set; }
        public long IdMerk { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedHost { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedHost { get; set; }

        public virtual OwnerStore IdStoreNavigation { get; set; }
    }
}
