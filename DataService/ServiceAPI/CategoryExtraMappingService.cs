using AutoMapper;
using DataService.Model.Entity;
using DataService.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.ServiceAPI
{
    public interface ICategoryExtraMappingService : IBaseService<CategoryExtraMapping, CategoryExtraMappingViewModel>
    {
        IEnumerable<CategoryExtraMappingViewModel> GetAllCategoryExtraMappings();
        IEnumerable<CategoryExtraMappingViewModel> GetCategoryExtraMappingsByExtraCategoryId(int extraCategoryId);
    }
    public class CategoryExtraMappingService : BaseService<CategoryExtraMapping, CategoryExtraMappingViewModel>, ICategoryExtraMappingService
    {
        public CategoryExtraMappingService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public IEnumerable<CategoryExtraMappingViewModel> GetAllCategoryExtraMappings()
        {
            var result = this.Get(p=>p.IsEnable == true);
            return result;
        }

        public IEnumerable<CategoryExtraMappingViewModel> GetCategoryExtraMappingsByExtraCategoryId(int extraCategoryId)
        {
            var result = this.Get(p => p.ExtraCategoryId == extraCategoryId && p.IsEnable == true);
            return result;
        }
    }
}
