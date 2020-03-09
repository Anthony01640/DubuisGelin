using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Data.Entity
{
    public class User
    {
        public Guid Id { get; set; }

        public string Mail { get; set; }

        public IEnumerable<Table> TableEnfant { get; set; }
    }
}
