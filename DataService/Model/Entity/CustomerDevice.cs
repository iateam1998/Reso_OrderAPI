using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class CustomerDevice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Fcmtoken { get; set; }
        public int? DeviceType { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
