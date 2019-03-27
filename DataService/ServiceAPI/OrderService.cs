using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ServiceAPI
{
    public interface IOrderService : IBaseService<Order, OrderViewModel>
    {
        IEnumerable<OrderViewModel> GetOrders(int storeId, OrderRequestModel model);
        OrderViewModel GetOrderByRentID(int rentId);
    }

    public class OrderService : BaseService<Order, OrderViewModel>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<OrderViewModel> GetOrders(int storeId, OrderRequestModel model)
        {
            var result = this.GetActive(p => (p.StoreId == storeId) 
            && (model.involvedID == p.InvoiceId)
            && (model.personCount == null || model.personCount == p.PersonCount)
            && (model.totalInvolvedPrint == null || model.totalInvolvedPrint == p.TotalInvoicePrint)
            && (model.deliveryStatus == null || model.deliveryStatus == p.DeliveryStatus)
            && (model.customerTypeID == null || model.customerTypeID == p.CustomerTypeId)
            && (model.checkInPerson == null || model.checkInPerson == p.CheckInPerson)
            && (model.checkInHour == null || model.checkInHour == p.CheckinHour)
            && (model.totalAmount == p.TotalAmount)
            && (model.finalAmount == p.FinalAmount)
            && (model.isDiscountOrderDetail == null || (p.DiscountOrderDetail > 0 && model.isDiscountOrderDetail == true) || (p.DiscountOrderDetail == 0 && model.isDiscountOrderDetail == false))
            && (model.orderStatus == null || p.OrderStatus == model.orderStatus)
            && (model.orderType == null || p.OrderType == model.orderType)
            && (model.startDate == null || p.CheckInDate >= model.startDate) && (model.endDate == null || p.CheckInDate <= model.endDate)
            && (model.isDiscount == null || (p.Discount > 0 && model.isDiscount == true) || (p.Discount == 0 && model.isDiscount == false))
            );
            return result;
        }

        public OrderViewModel GetOrderByRentID(int rentId)
        {
            var result = this.FirstOrDefaultActive(p => p.RentId == rentId);
            return result;
        }
    }
}
