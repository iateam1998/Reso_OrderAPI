using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class OrderApiViewModelForUpdate
    {
        [Required]
        public int RentID { get; set; }
        public string InvoiceID { get; set; }
        public System.DateTime CheckInDate { get; set; }
        public System.DateTime CheckOutDate { get; set; }
        public System.DateTime ApproveDate { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public double DiscountOrderDetail { get; set; }
        public double FinalAmount { get; set; }
        public int OrderStatus { get; set; }
        public int OrderType { get; set; }
        public string Notes { get; set; }
        public string FeeDescription { get; set; }
        public string CheckInPerson { get; set; }
        public string CheckOutPerson { get; set; }
        public string ApprovePerson { get; set; }
        public int CustomerID { get; set; }
        public int SourceID { get; set; }
        public int TableId { get; set; }
        public bool IsFixedPrice { get; set; }
        public System.DateTime LastRecordDate { get; set; }
        public string ServedPerson { get; set; }
        public string DeliveryAddress { get; set; }
        public int DeliveryStatus { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryCustomer { get; set; }
        public int SourceType { get; set; }
        public int TotalInvoicePrint { get; set; }
        public double VAT { get; set; }
        public double VATAmount { get; set; }
        public int NumberOfGuest { get; set; }

        public string VoucherCode { get; set; }

        public string Att1 { get; set; }
        public string Att2 { get; set; }
        public string Att3 { get; set; }
        public string Att4 { get; set; }
        public string Att5 { get; set; }

        public int GroupPaymentStatus { get; set; }

        //public int StoreId { get; set; }
        public List<OrderDetailApiViewModelForUpdate> OrderDetailViewModels { get; set; }
        public List<PaymentApiViewModelForUpdate> PaymentMs { get; set; }
        public List<OrderPromotionMappingModelForUpdate> OrderPromotionMappingMs { get; set; }
        public Nullable<System.DateTime> LastModifiedPayment { get; set; }
        //{ get return DateTime.Now; set; }
        public Nullable<System.DateTime> LastModifiedOrderDetail { get; set; }

        public OrderApiViewModelForUpdate()
        {
            OrderDetailViewModels = new List<OrderDetailApiViewModelForUpdate>();
            PaymentMs = new List<PaymentApiViewModelForUpdate>();
            OrderPromotionMappingMs = new List<OrderPromotionMappingModelForUpdate>();
        }

    }
    public class OrderDetailApiViewModelForUpdate
    {
        public OrderDetailApiViewModelForUpdate()
        {
            OrderDetailPromotionMappingMs = new List<OrderDetailPromotionMappingModelForUpdate>();
        }
        public int OrderDetailID { get; set; }
        //public int RentId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double FinalAmount { get; set; }
        public double TotalAmount { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
        public bool isAddition { get; set; }
        public int TaxValue { get; set; }
        public double UnitPrice { get; set; }
        public int ProductType { get; set; }
        public int? ParentId { get; set; }
        public int ProductOrderType { get; set; }
        public int ItemQuantity { get; set; }
        //public int StoreId { get; set; }
        public int? TmpDetailId { get; set; }
        public List<OrderDetailPromotionMappingModelForUpdate> OrderDetailPromotionMappingMs { get; set; }
        //public OrderPromotionMappingModel OrderPromotionMapping { get; set; }
        //public OrderDetailPromotionMappingModel OrderDetailPromotionMapping { get; set; }
        public Nullable<int> OrderPromotionMappingId { get; set; }
        public Nullable<int> OrderDetailPromotionMappingId { get; set; }
    }

    public class PaymentApiViewModelForUpdate
    {
        public int PaymentID { get; set; }
        //public int RentId { get; set; }
        public int Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal FCAmount { get; set; }
        public string Notes { get; set; }
        public System.DateTime PayTime { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public string CardCode { get; set; }
    }

    public class OrderPromotionMappingModelForUpdate
    {
        public int Id { get; set; }
        public int RentId { get; set; }
        [JsonProperty("PromotionId")]
        public string PromotionCode { get; set; }
        [JsonProperty("PromotionDetailId")]
        public string PromotionDetailCode { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<int> DiscountRate { get; set; }
        public int MappingIndex { get; set; }
        public Nullable<int> TmpMappingId { get; set; }
    }

    public class OrderDetailPromotionMappingModelForUpdate
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        [JsonProperty("PromotionId")]
        public string PromotionCode { get; set; }
        [JsonProperty("PromotionDetailId")]
        public string PromotionDetailCode { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<int> DiscountRate { get; set; }
        public int MappingIndex { get; set; }
        public Nullable<int> TmpMappingId { get; set; }
    }
}
