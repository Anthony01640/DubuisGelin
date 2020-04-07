using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Data.Entity
{
    public class Value
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int IdLiaison { get; set; }

        public LiaisonValueChamps LiaisonValueChamps { get; set; }

        public int ChampsId { get; set; }

        public Champs Champs { get; set; }
    }
}
