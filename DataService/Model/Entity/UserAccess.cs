using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class UserAccess
    {
        public int Id { get; set; }
        public int? UserAccessCampaignId { get; set; }
    }
}
