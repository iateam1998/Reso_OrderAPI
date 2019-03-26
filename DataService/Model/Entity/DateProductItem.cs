using System;
using System.Collections.Generic;

namespace DataService.Model.Entity
{
    public partial class DateProductItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ProductItemId { get; set; }
        public string ProductItemName { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
