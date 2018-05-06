using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class PropuestaBalanceo
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Num. Portafolio")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string NumPropuesta { get; set; }

        [Display(Name = "Cod. Portafolio")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int PortafolioId { get; set; }

        [Display(Name = "Portafolio")]
        public virtual Portafolio Portafolio { get; set; }

        [Display(Name = "Fecha creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Cod. Estado")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int EstadoId { get; set; }

        [Display(Name = "Estado")]
        public virtual Estado Estado { get; set; }

        public EstadoType EstadoType => (EstadoType)EstadoId;

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string UserId { get; set; }

        public virtual ICollection<PropuestaBalanceoDetalle> PropuestaBalanceoDetalles { get; set; }
    }
}
