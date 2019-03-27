using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ServiceAPI
{
    public interface IOrderDetailService : IBaseService<OrderDetail, OrderDetailViewModel>
    {
        IEnumerable<OrderDetailViewModel> GetAllOrderDetailByRentID(int rentId, OrderDetailRequestModel model);
        OrderDetailViewModel GetOrderDetailByIDSync(int orderDetailID);
    }

    public class OrderDetailService : BaseService<OrderDetail, OrderDetailViewModel>, IOrderDetailService
    {
        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<OrderDetailViewModel> GetAllOrderDetailByRentID(int rentId, OrderDetailRequestModel model)
        {
            var result = this.Get(p => (p.RentId == rentId)
            && (model.productID == null || model.productID == p.ProductId)
            && (model.totalAmount == null || model.totalAmount == p.TotalAmount)
            && (model.quantity == null || model.quantity == p.Quantity)
            && (model.startDate == null || model.startDate <= p.OrderDate) && (model.endDate == null || model.endDate >= p.OrderDate)
            && (model.status == null || model.status == p.Status)
            && (model.finalAmount == null || model.finalAmount == p.FinalAmount)
            && (model.isDiscount == null || (p.Discount > 0 && model.isDiscount == true) || (p.Discount == 0 && model.isDiscount == false))
            && (model.unitPrice == null || model.unitPrice == p.UnitPrice)
            && (model.storeID == null || model.storeID == p.StoreId)
            && (model.itemQuantity == null || model.itemQuantity == p.ItemQuantity)
            && (model.tmpDetailId == null || model.tmpDetailId == p.TmpDetailId)
            );
            
            return result;
        }

        public OrderDetailViewModel GetOrderDetailByIDSync(int orderDetailID)
        {
            var result = this.FirstOrDefaultActive(p => p.OrderDetailId == orderDetailID);
            return result;
        }
    }
}
