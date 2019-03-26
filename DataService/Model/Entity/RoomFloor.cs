using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class RoomFloor
    {
        public RoomFloor()
        {
            Room = new HashSet<Room>();
        }

        public int FloorId { get; set; }
        public string FloorName { get; set; }
        public int? Position { get; set; }
        public int StoreId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
