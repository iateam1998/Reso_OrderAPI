using DataService.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class CategoryExtraMappingViewModel : BaseViewModel<CategoryExtraMapping>
    {
        public int Id { get; set; }
        public int PrimaryCategoryId { get; set; }
        public int ExtraCategoryId { get; set; }
        public bool IsEnable { get; set; }
    }
}
