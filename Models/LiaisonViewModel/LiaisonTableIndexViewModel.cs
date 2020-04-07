using DubuisGelin.Models.ValueViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Models.LiaisonViewModel
{
    public class LiaisonTableIndexViewModel
    {
        public int Id { get; set; }

        public List<ValuesViewModel> ListeValue { get; set; }
    }
}
