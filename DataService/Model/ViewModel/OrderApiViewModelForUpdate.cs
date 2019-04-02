using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class OrderApiViewModelForUpdate
    {
        //public int OrderId { get; set; }
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
        public List<OrderDetailApiViewModel> OrderDetailViewModels { get; set; }
        public List<PaymentApiViewModel> PaymentMs { get; set; }
        public List<OrderPromotionMappingModel> OrderPromotionMappingMs { get; set; }
        public Nullable<System.DateTime> LastModifiedPayment { get; set; }
        //{ get return DateTime.Now; set; }
        public Nullable<System.DateTime> LastModifiedOrderDetail { get; set; }

        public OrderApiViewModelForUpdate()
        {
            OrderDetailViewModels = new List<OrderDetailApiViewModel>();
            PaymentMs = new List<PaymentApiViewModel>();
            OrderPromotionMappingMs = new List<OrderPromotionMappingModel>();
        }

    }
}
