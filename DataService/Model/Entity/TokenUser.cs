using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class TokenUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
