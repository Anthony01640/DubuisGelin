using DubuisGelin.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Data.Entity
{
    public class Champs
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public IEnumerable<Value> Values { get; set; }

        public TypeEnum TypeEnum { get; set; }
    }
}
