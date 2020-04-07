using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DubuisGelin.Services.Enums;
using DubuisGelin.Data.Entity;

namespace DubuisGelin.Models.ChampsViewModel
{
    public class AddChampsToTableViewModel
    {
        public Table Table { get; set; }
        public int IdTable { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TypeEnum Type { get; set; }
    }
}
