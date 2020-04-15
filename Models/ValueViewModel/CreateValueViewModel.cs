using DubuisGelin.Models.ChampsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Models.ValueViewModel
{

    public class CreateValueViewModel
    {
        public int IdLiaison { get; set; }

        public int IdTable { get; set; }

        public IEnumerable<ChampsCreateValueViewModel> ListeChamps { get; set; }

        public IEnumerable<int> ListeIdChamps { get; set; }

        public List<string> ListeNomValeurs { get; set; }

    }

}
