using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ServiceAPI
{
    public interface IStoreService : IBaseService<Store,StoreViewModel>
    {
        StoreViewModel GetStoreByIdSync(int storeId);
        IEnumerable<StoreViewModel> GetAllStoreByBrandId(int brandId);
        IEnumerable<StoreViewModel> GetAllStoreAvailable();
    }
    public class StoreService : BaseService<Store, StoreViewModel>, IStoreService
    {
        public StoreService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public StoreViewModel GetStoreByIdSync(int storeId)
        {
            var store = this.FirstOrDefaultActive(p => p.Id == storeId);
            return store;
        }

        public IEnumerable<StoreViewModel> GetAllStoreByBrandId(int brandId)
        {
            var result = this.GetActive(p => p.BrandId == brandId);
            return result;
        }

        public IEnumerable<StoreViewModel> GetAllStoreAvailable()
        {
            var result = this.Get(p => p.IsAvailable == true);
            return result;
        }
    }
}
