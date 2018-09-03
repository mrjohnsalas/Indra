using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indra.Model.Models
{
    [Table("SolicitudesRecursoDetalle")]
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

        [Display(Name = "Estado")]
        [NotMapped]
        public Enums.EstadoType EstadoType => (QuantityPending == 0) ? Enums.EstadoType.Atendido : Enums.EstadoType.Pendiente;

        [Display(Name = "Cant. Solicitada")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Quantity { get; set; }

        [Display(Name = "Cant. Atendida")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal QuantityAttended { get; set; }

        [Display(Name = "Cant. Pendiente")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal QuantityPending => Quantity - QuantityAttended;

        [Display(Name = "Cant. Disponible")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal QuantityAvailable { get; set; }

        [Display(Name = "Cant. a Asignar")]
        [NotMapped]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal QuantityToAssign { get; set; }

        [Display(Name = "Cod. Tipo Solicitud Recurso")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int TipoSolicitudRecursoId { get; set; }

        [Display(Name = "Tipo Solicitud Recurso")]
        public virtual TipoSolicitudRecurso TipoSolicitudRecurso { get; set; }

        public Enums.TipoSolicitudRecursoType TipoSolicitudRecursoType => (Enums.TipoSolicitudRecursoType)TipoSolicitudRecursoId;

        [Display(Name = "Nro. Días")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal? DiasAlquiler { get; set; }

        [Display(Name = "Costo Total")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal CostoTotal { get; set; }

        public virtual ICollection<PropuestaBalanceoDetalle> PropuestaBalanceoDetalles { get; set; }
    }
}