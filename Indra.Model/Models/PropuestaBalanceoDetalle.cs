using System.ComponentModel.DataAnnotations;

namespace Indra.Model.Models
{
    public class PropuestaBalanceoDetalle
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cod. Propuesta Balanceo")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int PropuestaBalanceoId { get; set; }

        [Display(Name = "Propuesta Balanceo")]
        public virtual PropuestaBalanceo PropuestaBalanceo { get; set; }

        [Display(Name = "Cod. Solicitud Recurso Detalle")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int SolicitudRecursoDetalleId { get; set; }

        [Display(Name = "Solicitud Recurso Detalle")]
        public virtual SolicitudRecursoDetalle SolicitudRecursoDetalle { get; set; }

        [Display(Name = "Cant. Atendida")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Quantity { get; set; }
    }
}
