using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Data.Entity
{
    public class LiaisonValueChamps
    {
        public int Id { get; set; }

        public List<Value> Values { get; set; }

        public int IdTable { get; set; }

        public Table Table { get; set; }
    }
}
