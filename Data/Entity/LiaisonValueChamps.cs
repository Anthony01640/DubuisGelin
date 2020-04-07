using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Data.Entity
{
    public class LiaisonValueChamps
    {
        public int Id { get; set; }

        public IEnumerable<Value> Values { get; set; }
    }
}
