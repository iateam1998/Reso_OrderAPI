using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model.ViewModel
{
    public partial class AccountViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public int addBalanceValue { get; set; }
    }
}
