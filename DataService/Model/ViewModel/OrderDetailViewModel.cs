using DataService.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class OrderDetailViewModel : BaseViewModel<OrderDetail>
    {
        public int OrderDetailId { get; set; }
        public int RentId { get; set; }
        public int ProductId { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public double FinalAmount { get; set; }
        public bool? IsAddition { get; set; }
        public string DetailDescription { get; set; }
        public double Discount { get; set; }
        public double? TaxPercent { get; set; }
        public double? TaxValue { get; set; }
        public double UnitPrice { get; set; }
        public int? ProductType { get; set; }
        public int? ParentId { get; set; }
        public int? StoreId { get; set; }
        public int? ProductOrderType { get; set; }
        public int ItemQuantity { get; set; }
        public int? TmpDetailId { get; set; }
        public int? OrderDetailPromotionMappingId { get; set; }
        public int? OrderPromotionMappingId { get; set; }
        public string OrderDetailAtt1 { get; set; }
        public string OrderDetailAtt2 { get; set; }
        public bool? Active { get; set; }

        public virtual OrderDetailPromotionMapping OrderDetailPromotionMappings { get; set; }
        public virtual OrderPromotionMapping OrderPromotionMappings { get; set; }
        public virtual OrderDetail Parents { get; set; }
        public virtual Product Products { get; set; }
        public virtual Order Rents { get; set; }
        public virtual ICollection<OrderDetail> InverseParents { get; set; }
        public virtual ICollection<OrderDetailPromotionMapping> OrderDetailPromotionMappingNavigations { get; set; }
    }

    public class OrderDetailRequestModel
    {
        public int? productID { get; set; }
        public int? totalAmount { get; set; }
        public int? quantity { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? status { get; set; }
        public int? finalAmount { get; set; }
        public bool? isDiscount { get; set; }
        public int? unitPrice { get; set; }
        public int? rentID { get; set; }
        public int? itemQuantity { get; set; }
        public int? tmpDetailId { get; set; }
    }
}
