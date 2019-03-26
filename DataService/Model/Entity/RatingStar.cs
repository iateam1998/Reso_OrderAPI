using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class RatingStar
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int? Rate { get; set; }
    }
}
