using System;
using System.Collections.Generic;

namespace CariBengkel.Repository.Entity.Model
{
    public partial class TransactionBooking
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public long IdCustomer { get; set; }
        public long IdVehicleType { get; set; }
        public long IdVehicleBrand { get; set; }
        public string VehicleNumber { get; set; }
        public string Problem { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedHost { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedHost { get; set; }
    }
}
