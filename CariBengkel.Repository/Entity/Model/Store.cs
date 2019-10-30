using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class Store
    {
        public Store()
        {
            TrProduct = new HashSet<TrProduct>();
            TrServicePackage = new HashSet<TrServicePackage>();
        }

        public long Id { get; set; }
        public long IdOwner { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Maps { get; set; }
        public string OpenDay { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public string CloseDay { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedHost { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedHost { get; set; }
        public bool? IsClose { get; set; }

        public virtual Owner IdOwnerNavigation { get; set; }
        public virtual ICollection<TrProduct> TrProduct { get; set; }
        public virtual ICollection<TrServicePackage> TrServicePackage { get; set; }
    }
}
