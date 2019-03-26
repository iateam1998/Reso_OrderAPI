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
        IEnumerable<OrderViewModel> GetOrdersByStoreId(int storeId);
    }

    public class OrderService : BaseService<Order, OrderViewModel>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<OrderViewModel> GetOrdersByStoreId(int storeId)
        {
            var result = this.GetActive(p => p.StoreId == storeId);
            return result;
        }
    }
}
