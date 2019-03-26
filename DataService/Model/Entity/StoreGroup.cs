﻿using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class StoreGroup
    {
        public StoreGroup()
        {
            StoreGroupMapping = new HashSet<StoreGroupMapping>();
        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<StoreGroupMapping> StoreGroupMapping { get; set; }
    }
}
