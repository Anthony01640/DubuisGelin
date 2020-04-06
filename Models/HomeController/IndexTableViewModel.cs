using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DubuisGelin.Models.ChampsViewModel;
using DubuisGelin.Models.LiaisonViewModel;
using DubuisGelin.Models.ValueViewModel;

namespace DubuisGelin.Models.HomeController
{
    public class IndexTableViewModel
    {
        public string NameTable { get; set; }

        public List<ChampViewModel> ListeChamps { get; set; } 

        public List<LiaisonTableIndexViewModel> ListeLiaison { get; set; }
    }
}
