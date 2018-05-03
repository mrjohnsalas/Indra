using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class Programa
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }
    }
}
