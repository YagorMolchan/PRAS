using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRAS.Models.ViewModels
{
    public class NewListViewModel
    {
        public PageViewModel PageViewModel { get; set; }

        public IEnumerable<PRAS.Models.Entities.New> News { get; set; }
    }
}
