using DubuisGelin.Models.TableViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Models.HomeController
{
    public class IndexViewModel
    {
        public IEnumerable<TableUserViewModel> TableUtilisateur { get; set; }

        public Guid IdUser { get; set; }
    }
}
