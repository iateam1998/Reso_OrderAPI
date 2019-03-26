using DataService.Model.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class ProductItemCategoryViewModel : BaseViewModel<ProductItemCategory>
    {
        public IEnumerable<SelectList> AvailbleProductCategories { get; set; }
    }
}
