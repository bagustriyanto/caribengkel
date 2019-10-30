using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class TrServicePackageDetail
    {
        public long Id { get; set; }
        public long IdServicePackage { get; set; }
        public long Item { get; set; }
        public long? IdItemType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedHost { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedHost { get; set; }

        public virtual TrServicePackage IdServicePackageNavigation { get; set; }
    }
}
