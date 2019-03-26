using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class StoreUser
    {
        public string Username { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
