using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Data.Entity
{
    public class Table
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public int ChampsId { get; set; }

        public IEnumerable<Champs> Champs { get; set; }
        public IEnumerable<LiaisonValueChamps> LiaisonValue { get; set; }
    }
}
