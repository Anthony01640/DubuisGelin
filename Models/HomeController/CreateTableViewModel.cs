using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Models.HomeController
{
    public class CreateTableViewModel
    {
        public Guid IdUser { get; set; }

        [Required]
        public string Nom { get; set; }
    }
}
