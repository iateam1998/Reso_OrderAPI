using DataService.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class ProductItemCompositionMappingViewModel : BaseViewModel<ProductItemCompositionMapping>
    {
        public ProductItemViewModel ProductItem { get; set; }
    }
}
