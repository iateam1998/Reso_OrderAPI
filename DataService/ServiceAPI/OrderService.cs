using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using SkyWeb.DatVM.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper.QueryableExtensions;

using System.Threading.Tasks;
using SkyWeb.DatVM.Data;
using BlogPostCollection = DataService.Model.Entity.BlogPostCollection;

namespace DataService.ServiceAPI
{
    public interface IOrderService : IBaseService<Order, OrderViewModel>
    {
        IEnumerable<OrderViewModel> GetOrders(OrderRequestModel model);
        //IEnumerable<OrderViewModel> GetOrders(int storeId, OrderRequestModel model);
        //OrderViewModel GetOrderByRentID(int storeId, int rentId);
        OrderViewModel GetOrderByRentID(OrderRequestModel model);
        bool CreateOrder(int storeId, OrderApiViewModel orderRequest);
        bool UpdateOrder(int storeId, OrderApiViewModelForUpdate orderRequest);
    }

    public class OrderService : BaseService<Order, OrderViewModel>, IOrderService
    {
        private readonly IServiceProvider _serviceProvider;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IServiceProvider serviceProvider) : base(unitOfWork, mapper)
        {
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<OrderViewModel> GetOrders(OrderRequestModel model)
        {
            var result = this.GetActive(p => (p.StoreId == model.storeId)
           && (model.rentId == null || p.RentId == model.rentId)
           && (model.involvedID == null || model.involvedID == p.InvoiceId)
           && (model.personCount == null || model.personCount == p.PersonCount)
           && (model.totalInvolvedPrint == null || model.totalInvolvedPrint == p.TotalInvoicePrint)
           && (model.deliveryStatus == null || model.deliveryStatus == p.DeliveryStatus)
           && (model.customerTypeID == null || model.customerTypeID == p.CustomerTypeId)
           && (model.checkInPerson == null || model.checkInPerson == p.CheckInPerson)
           && (model.checkInHour == null || model.checkInHour == p.CheckinHour)
           && (model.totalAmount == null || model.totalAmount == p.TotalAmount)
           && (model.finalAmount == null || model.finalAmount == p.FinalAmount)
           && (model.isDiscountOrderDetail == null || (p.DiscountOrderDetail > 0 && model.isDiscountOrderDetail == true) || (p.DiscountOrderDetail == 0 && model.isDiscountOrderDetail == false))
           && (model.orderStatus == null || p.OrderStatus == model.orderStatus)
           && (model.orderType == null || p.OrderType == model.orderType)
           && (model.startDate == null || p.CheckInDate >= model.startDate) && (model.endDate == null || p.CheckInDate <= model.endDate)
           && (model.isDiscount == null || (p.Discount > 0 && model.isDiscount == true) || (p.Discount == 0 && model.isDiscount == false))
           && (model.paymentId == null || (p.Payment.FirstOrDefault(q => q.PaymentId == model.paymentId) != null))
           );
            return result;

        }
        private IEnumerable<OrderViewModel> GetOrders(int storeId, OrderRequestModel model)
        {
            var result = this.GetActive(p => (p.StoreId == storeId)
            && (model.involvedID == null || model.involvedID == p.InvoiceId)
            && (model.personCount == null || model.personCount == p.PersonCount)
            && (model.totalInvolvedPrint == null || model.totalInvolvedPrint == p.TotalInvoicePrint)
            && (model.deliveryStatus == null || model.deliveryStatus == p.DeliveryStatus)
            && (model.customerTypeID == null || model.customerTypeID == p.CustomerTypeId)
            && (model.checkInPerson == null || model.checkInPerson == p.CheckInPerson)
            && (model.checkInHour == null || model.checkInHour == p.CheckinHour)
            && (model.totalAmount == null || model.totalAmount == p.TotalAmount)
            && (model.finalAmount == null || model.finalAmount == p.FinalAmount)
            && (model.isDiscountOrderDetail == null || (p.DiscountOrderDetail > 0 && model.isDiscountOrderDetail == true) || (p.DiscountOrderDetail == 0 && model.isDiscountOrderDetail == false))
            && (model.orderStatus == null || p.OrderStatus == model.orderStatus)
            && (model.orderType == null || p.OrderType == model.orderType)
            && (model.startDate == null || p.CheckInDate >= model.startDate) && (model.endDate == null || p.CheckInDate <= model.endDate)
            && (model.isDiscount == null || (p.Discount > 0 && model.isDiscount == true) || (p.Discount == 0 && model.isDiscount == false))
            );
            return result;
        }
        private OrderViewModel GetOrderByRentID(int storeId, int rentId)
        //public OrderViewModel GetOrderByRentID(OrderRequestModel model)
        {
            var list = this.GetOrders(new OrderRequestModel());
            var result = list.FirstOrDefault(p => p.RentId == rentId);
            return result;

        }

        public OrderViewModel GetOrderByRentID(OrderRequestModel model)
        {
            var list = this.GetOrders(new OrderRequestModel());
            var result = list.FirstOrDefault(p => p.StoreId == model.storeId);
            return result;

        }

        public bool CreateOrder(int storeId, OrderApiViewModel orderRequest)
        {
            var _orderDetailService = ServiceFactory.CreateService<IOrderDetailService>(_serviceProvider);
            var _paymentService = ServiceFactory.CreateService<IPaymentService>(_serviceProvider);
            var order = new OrderViewModel();
            MapOrder(orderRequest, order, storeId);
            this.Create(order);
            var rId = this.LastOrDefault().RentId;
            foreach (var orderDetailRequest in orderRequest.OrderDetailViewModels)
            {
                var orderDetail = new OrderDetailViewModel();
                MapOrderDetail(orderDetailRequest, orderDetail, storeId);
                orderDetail.RentId = rId;
                orderDetail.IsAddition = false;
                orderDetail.Active = true;
                _orderDetailService.Create(orderDetail);
            }
            if (orderRequest.PaymentMs.Count > 0)
            {
                foreach (var paymentRequest in orderRequest.PaymentMs)
                {
                    var payment = new PaymentViewModel();
                    MapPayment(paymentRequest, payment);
                    payment.ToRentId = rId;
                    //payment = true;
                    _paymentService.Create(payment);
                }
                //orderRequest.Room.CurrentRentId = -1;
            }
            return true;
        }

        public bool UpdateOrder(int storeId, OrderApiViewModelForUpdate orderRequest)
        {
            var _orderDetailService = ServiceFactory.CreateService<IOrderDetailService>(_serviceProvider);
            var _paymentService = ServiceFactory.CreateService<IPaymentService>(_serviceProvider);
            var order = new OrderViewModel();
            if (orderRequest.PaymentMs.Count > 0)
            {
                foreach (var paymentRequest in orderRequest.PaymentMs)
                {
                    var payment = new PaymentViewModel();
                    MapPaymentForUpdate(paymentRequest, payment);
                    payment.ToRentId = orderRequest.RentID;
                    //payment = true;
                    _paymentService.Update(payment);
                }
                //orderRequest.Room.CurrentRentId = -1;
            }
            foreach (var orderDetailRequest in orderRequest.OrderDetailViewModels)
            {
                var orderDetail = new OrderDetailViewModel();
                MapOrderDetailForUpdate(orderDetailRequest, orderDetail, storeId);
                orderDetail.RentId = orderRequest.RentID;
                orderDetail.Active = true;
                _orderDetailService.Update(orderDetail);
            }
            MapOrderForUpdate(orderRequest, order, storeId);
            //if (orderRequest.)
            this.Update(order);
            return true;
        }

        private void MapOrder(OrderApiViewModel source, OrderViewModel destination, int storeId)
        {
            //destination.RentId = source.OrderId;
            destination.OrderStatus = source.OrderStatus;
            destination.CheckInPerson = source.CheckInPerson;
            destination.DeliveryStatus = source.DeliveryStatus;
            destination.InvoiceId = source.InvoiceID;
            //destination.CheckInDate = source.CheckInDate;
            destination.CheckInDate = DateTime.UtcNow;
            destination.CheckOutDate = DateTime.UtcNow;      //TODO: change
            destination.ApproveDate = DateTime.UtcNow;       //TODO: change
            destination.TotalAmount = source.TotalAmount;
            destination.Discount = source.Discount;
            destination.DiscountOrderDetail = source.DiscountOrderDetail;
            destination.FinalAmount = source.FinalAmount;
            destination.OrderType = source.OrderType;
            destination.Notes = source.Notes;
            destination.FeeDescription = source.FeeDescription;
            destination.CheckOutPerson = source.CheckOutPerson;
            destination.ApprovePerson = source.ApprovePerson;
            if (source.CustomerID != 0)
                destination.CustomerId = source.CustomerID;
            destination.IsFixedPrice = source.IsFixedPrice;
            destination.ServedPerson = source.ServedPerson;
            destination.StoreId = storeId;
            destination.SourceId = source.SourceID;
            destination.SourceType = 0;
            destination.DeliveryAddress = source.DeliveryAddress;
            destination.TotalInvoicePrint = source.TotalInvoicePrint;
            destination.Vat = source.VAT;
            destination.Vatamount = source.VATAmount;
            destination.NumberOfGuest = source.NumberOfGuest;
            destination.Att1 = source.Att1;
            destination.Att2 = source.Att2;
            destination.Att3 = source.Att3;
            destination.Att4 = source.Att4;
            destination.Att5 = source.Att5;
            destination.GroupPaymentStatus = source.GroupPaymentStatus;
            destination.DeliveryReceiver = source.DeliveryCustomer;
            destination.DeliveryPhone = source.DeliveryPhone;
            destination.LastModifiedPayment = source.LastModifiedPayment;
            destination.LastModifiedOrderDetail = source.LastModifiedOrderDetail;
        }

        private void MapOrderForUpdate(OrderApiViewModelForUpdate source, OrderViewModel destination, int storeId)
        {
            destination.RentId = source.RentID;
            destination.OrderStatus = source.OrderStatus;
            destination.CheckInPerson = source.CheckInPerson;
            destination.DeliveryStatus = source.DeliveryStatus;
            destination.InvoiceId = source.InvoiceID;
            //destination.CheckInDate = source.CheckInDate;
            destination.CheckInDate = DateTime.UtcNow;
            destination.CheckOutDate = DateTime.UtcNow;      //TODO: change
            destination.ApproveDate = DateTime.UtcNow;       //TODO: change
            destination.TotalAmount = source.TotalAmount;
            destination.Discount = source.Discount;
            destination.DiscountOrderDetail = source.DiscountOrderDetail;
            destination.FinalAmount = source.FinalAmount;
            destination.OrderType = source.OrderType;
            destination.Notes = source.Notes;
            destination.FeeDescription = source.FeeDescription;
            destination.CheckOutPerson = source.CheckOutPerson;
            destination.ApprovePerson = source.ApprovePerson;
            if (source.CustomerID != 0)
                destination.CustomerId = source.CustomerID;
            destination.IsFixedPrice = source.IsFixedPrice;
            destination.ServedPerson = source.ServedPerson;
            destination.StoreId = storeId;
            destination.SourceId = source.SourceID;
            destination.SourceType = 0;
            destination.DeliveryAddress = source.DeliveryAddress;
            destination.TotalInvoicePrint = source.TotalInvoicePrint;
            destination.Vat = source.VAT;
            destination.Vatamount = source.VATAmount;
            destination.NumberOfGuest = source.NumberOfGuest;
            destination.Att1 = source.Att1;
            destination.Att2 = source.Att2;
            destination.Att3 = source.Att3;
            destination.Att4 = source.Att4;
            destination.Att5 = source.Att5;
            destination.GroupPaymentStatus = source.GroupPaymentStatus;
            destination.DeliveryReceiver = source.DeliveryCustomer;
            destination.DeliveryPhone = source.DeliveryPhone;
            destination.LastModifiedPayment = source.LastModifiedPayment;
            destination.LastModifiedOrderDetail = source.LastModifiedOrderDetail;
        }

        /// <summary>
        /// Map orderdetail data form source(model) to destination
        /// </summary>
        private void MapOrderDetail(OrderDetailApiViewModel source, OrderDetailViewModel destination, int storeId)
        {
            destination.ProductId = source.ProductId;
            destination.StoreId = storeId;
            destination.TotalAmount = source.TotalAmount;
            destination.Quantity = source.Quantity;
            //destination.OrderDate = source.OrderDate;
            destination.OrderDate = DateTime.UtcNow;
            destination.Status = source.Status;
            destination.FinalAmount = source.FinalAmount;
            destination.Discount = source.Discount;
            destination.TaxValue = source.TaxValue;
            destination.UnitPrice = source.UnitPrice;
            destination.ProductType = source.ProductType;
            destination.ParentId = source.ParentId;
            destination.ProductOrderType = source.ProductOrderType;
            destination.ItemQuantity = source.ItemQuantity;
            destination.TmpDetailId = source.TmpDetailId;
            destination.OrderPromotionMappingId = source.OrderPromotionMappingId;
            destination.OrderDetailPromotionMappingId = source.OrderDetailPromotionMappingId;
        }

        private void MapOrderDetailForUpdate(OrderDetailApiViewModelForUpdate source, OrderDetailViewModel destination, int storeId)
        {
            destination.OrderDetailId = source.OrderDetailID;
            destination.ProductId = source.ProductId;
            destination.StoreId = storeId;
            destination.TotalAmount = source.TotalAmount;
            destination.Quantity = source.Quantity;
            //destination.OrderDate = source.OrderDate;
            destination.OrderDate = DateTime.UtcNow;
            destination.Status = source.Status;
            if (source.isAddition != null)
            {
                destination.IsAddition = source.isAddition;
            } else destination.IsAddition = false;
            destination.FinalAmount = source.FinalAmount;
            destination.Discount = source.Discount;
            destination.TaxValue = source.TaxValue;
            destination.UnitPrice = source.UnitPrice;
            destination.ProductType = source.ProductType;
            destination.ParentId = source.ParentId;
            destination.ProductOrderType = source.ProductOrderType;
            destination.ItemQuantity = source.ItemQuantity;
            destination.TmpDetailId = source.TmpDetailId;
            destination.OrderPromotionMappingId = source.OrderPromotionMappingId;
            destination.OrderDetailPromotionMappingId = source.OrderDetailPromotionMappingId;
        }

        /// <summary>
        /// Map payment data form source(model) to destination
        /// </summary>
        private void MapPayment(PaymentApiViewModel source, PaymentViewModel destination)
        {
            destination.Amount = source.Amount;
            destination.CurrencyCode = source.CurrencyCode;
            destination.Fcamount = source.FCAmount;
            destination.Notes = source.Notes;
            destination.PayTime = DateTime.UtcNow;
            destination.Status = source.Status;
            destination.Type = source.Type;
            destination.CardCode = source.CardCode;
        }

        private void MapPaymentForUpdate(PaymentApiViewModelForUpdate source, PaymentViewModel destination)
        {
            destination.PaymentId = source.PaymentID;
            destination.Amount = source.Amount;
            destination.CurrencyCode = source.CurrencyCode;
            destination.Fcamount = source.FCAmount;
            destination.Notes = source.Notes;
            destination.PayTime = DateTime.UtcNow;
            destination.Status = source.Status;
            destination.Type = source.Type;
            destination.CardCode = source.CardCode;
        }
    }
}
