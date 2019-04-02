using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.ServiceAPI
{
    public interface IOrderDetailService : IBaseService<OrderDetail, OrderDetailViewModel>
    {
        //IEnumerable<OrderDetailViewModel> GetAllOrderDetailByRentID(int rentId, OrderDetailRequestModel model);
        //OrderDetailViewModel GetOrderDetailByIDSync(int storeId, int orderDetailID);
        IEnumerable<OrderDetailViewModel> GetAllOrderDetailByRentID(OrderDetailRequestModel model);
        OrderDetailViewModel GetOrderDetailByIDSync(OrderDetailRequestModel model);
    }

    public class OrderDetailService : BaseService<OrderDetail, OrderDetailViewModel>, IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        private IEnumerable<OrderDetailViewModel> GetAllOrderDetailByRentID(int storeID, OrderDetailRequestModel model)
        {
            var result = this.GetActive(p => (p.StoreId == storeID)
            && (model.productID == null || model.productID == p.ProductId)
            && (model.totalAmount == null || model.totalAmount == p.TotalAmount)
            && (model.quantity == null || model.quantity == p.Quantity)
            && (model.startDate == null || model.startDate <= p.OrderDate) && (model.endDate == null || model.endDate >= p.OrderDate)
            && (model.status == null || model.status == p.Status)
            && (model.finalAmount == null || model.finalAmount == p.FinalAmount)
            && (model.isDiscount == null || (p.Discount > 0 && model.isDiscount == true) || (p.Discount == 0 && model.isDiscount == false))
            && (model.unitPrice == null || model.unitPrice == p.UnitPrice)
            && (model.rentID == null || model.rentID == p.RentId)
            && (model.itemQuantity == null || model.itemQuantity == p.ItemQuantity)
            && (model.tmpDetailId == null || model.tmpDetailId == p.TmpDetailId)
            );
            return result;
        }

        public IEnumerable<OrderDetailViewModel> GetAllOrderDetailByRentID( OrderDetailRequestModel model)
        {
            var result = this.GetActive(p => (p.StoreId == model.storeId)
            && (model.orderDetailId == null || model.orderDetailId == p.OrderDetailId)
            && (model.productID == null || model.productID == p.ProductId)
            && (model.totalAmount == null || model.totalAmount == p.TotalAmount)
            && (model.quantity == null || model.quantity == p.Quantity)
            && (model.startDate == null || model.startDate <= p.OrderDate) && (model.endDate == null || model.endDate >= p.OrderDate)
            && (model.status == null || model.status == p.Status)
            && (model.finalAmount == null || model.finalAmount == p.FinalAmount)
            && (model.isDiscount == null || (p.Discount > 0 && model.isDiscount == true) || (p.Discount == 0 && model.isDiscount == false))
            && (model.unitPrice == null || model.unitPrice == p.UnitPrice)
            && (model.rentID == null || model.rentID == p.RentId)
            && (model.itemQuantity == null || model.itemQuantity == p.ItemQuantity)
            && (model.tmpDetailId == null || model.tmpDetailId == p.TmpDetailId)
            );


            return result;
        }

        private OrderDetailViewModel GetOrderDetailByIDSync(int storeId, int orderDetailID)
        {
            var list = this.GetAllOrderDetailByRentID(storeId, new OrderDetailRequestModel());
            var result = list.FirstOrDefault(p => p.OrderDetailId == orderDetailID);
            return result;
        }

        public OrderDetailViewModel GetOrderDetailByIDSync(OrderDetailRequestModel model)
        {
            var list = this.GetAllOrderDetailByRentID(new OrderDetailRequestModel());
            var result = list.FirstOrDefault(p => p.OrderDetailId == model.orderDetailId);
            return result;
        }

        public void CreateOrderDetail(OrderDetailViewModel orderDetail)
        {
            this.Create(orderDetail);
        }
    }
}
