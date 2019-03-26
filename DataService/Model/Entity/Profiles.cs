﻿using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class Profiles
    {
        public Guid UserId { get; set; }
        public string PropertyNames { get; set; }
        public string PropertyValueStrings { get; set; }
        public byte[] PropertyValueBinary { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public virtual Users User { get; set; }
    }
}
