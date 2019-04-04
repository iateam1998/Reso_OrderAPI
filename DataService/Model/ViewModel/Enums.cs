using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace DataService.Model.ViewModel
{

    public static partial class Enums
    {

        public static string OrderTypeDisplayName(this int enumVal)
        {
            //switch (enumVal)
            //{
            //    case (int)OrderTypeEnum.AtStore:
            //        return DisplayName(OrderTypeEnum.AtStore);
            //    case (int)OrderTypeEnum.TakeAway:
            //        return DisplayName(OrderTypeEnum.TakeAway);
            //    case (int)OrderTypeEnum.Delivery:
            //        return DisplayName(OrderTypeEnum.Delivery);
            //    case (int)OrderTypeEnum.DropProduct:
            //        return DisplayName(OrderTypeEnum.DropProduct);
            //    case (int)OrderTypeEnum.OnlineProduct:
            //        return DisplayName(OrderTypeEnum.OnlineProduct);
            //    case (int)OrderTypeEnum.OrderCard:
            //        return DisplayName(OrderTypeEnum.OrderCard);
            //    case (int)OrderTypeEnum.MobileTakeAway:
            //        return DisplayName(OrderTypeEnum.MobileTakeAway);
            //    case (int)OrderTypeEnum.External:
            //        return DisplayName(OrderTypeEnum.External);



            //}
            return "Unknown";
        }

    }




    public enum OrderTypeEnum
    {
        [Display(Name = "Tại quán")]
        AtStore = 4,
        [Display(Name = "Mang đi")]
        TakeAway = 5,
        [Display(Name = "Giao hàng")]
        Delivery = 6,
        [Display(Name = "Bị hủy")]
        DropProduct = 8,
        [Display(Name = "Đặt hàng Online")]
        OnlineProduct = 1, // sản phẩm được đặt online
        [Display(Name = "Nạp thẻ")]
        OrderCard = 7,
        [Display(Name = "Mobile Delivery")]
        MobileDelivery = 9, // sản phẩm được đặt delivery của mobile
        [Display(Name = "Mobile TakeAway")]
        MobileTakeAway = 10,
        [Display(Name = "External")] //Sản phẩm đặt hàng từ đối tác
        External = 11
    }

    public enum PaymentTypeEnum
    {
        [Display(Name = "Tiền mặt")]
        Cash = 1,
        [Display(Name = "Thẻ")]
        Card = 2,
        [Display(Name = "Thẻ thành viên")]
        MemberPayment = 3,
        [Display(Name = "Voucher")]
        Voucher = 4,
        [Display(Name = "Tài khoản khách hàng")]
        AccountReceivable = 5,
        [Display(Name = "Khác")]
        Other = 6,
        [Display(Name = "MasterCard")]
        MasterCard = 7,
        [Display(Name = "VisaCard")]
        VisaCard = 8,
        [Display(Name = "Tiền thối")]
        ExchangeCash = 9,
        [Display(Name = "Tiền nạp vào tài khoản")]
        PaymentMember = 10,
        [Display(Name = "Khách nợ")]
        Debt = 11,
        [Display(Name = "Trả nợ")]
        PayDebt = 12,
        [Display(Name = "Momo")]
        MoMo = 21,
        [Display(Name = "GiftTalk")]
        GiftTalk = 22,
        [Display(Name = "ZaloPay")]
        ZaloPay = 23,
    }

}
