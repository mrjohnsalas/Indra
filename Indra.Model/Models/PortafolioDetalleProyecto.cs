using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class PortafolioDetalleProyecto
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cod. Portafolio")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int PortafolioId { get; set; }

        [Display(Name = "Portafolio")]
        public virtual Portafolio Portafolio { get; set; }

        [Display(Name = "Cod. Proyecto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ProyectoId { get; set; }

        [Display(Name = "Proyecto")]
        public virtual Proyecto Proyecto { get; set; }
    }
}