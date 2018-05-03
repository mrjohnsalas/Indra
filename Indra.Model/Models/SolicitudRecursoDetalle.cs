using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indra.Model.Models
{
    public class SolicitudRecursoDetalle
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cod. Solicitud Recurso")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int SolicitudRecursoId { get; set; }

        [Display(Name = "Solicitud Recurso")]
        public virtual SolicitudRecurso SolicitudRecurso { get; set; }

        [Display(Name = "Cod. Recurso")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int RecursoId { get; set; }

        [Display(Name = "Recurso")]
        public virtual Recurso Recurso { get; set; }

        [Display(Name = "Cant. Solicitada")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Quantity { get; set; }

        [Display(Name = "Cant. Disponible")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal QuantityAvailable => Quantity * 5;

        [Display(Name = "Cant. a Asignar")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal QuantityToAssign => Quantity;
    }
}