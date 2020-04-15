using DubuisGelin.Models.ChampsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Models.TableViewModel
{
    public class TableForDeleteChampsViewModel
    {
        public int Id { get; set; }

        public List<ChampViewModel> ListeChamps { get; set; }

        public List<int> ListeSelectId { get; set; }

    }
}
