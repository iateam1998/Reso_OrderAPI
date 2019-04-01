using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model.ViewModel
{
    public class PagingViewModel
    {
        public PagingViewModel() { }

        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int TotalItems { get; set; }
        public int? Start { get; }
        public int? End { get; }
        public int? TotalPages { get; }

        //public void RefineParameters(int defaultPageSize = 10);
    }
}
