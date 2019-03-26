using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class MenuRole
    {
        public int Id { get; set; }
        public int? MenuId { get; set; }
        public string RoleId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual AspNetRoles Role { get; set; }
    }
}
