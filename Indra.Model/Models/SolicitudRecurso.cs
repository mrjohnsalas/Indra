using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Indra.Model.Models
{
    public class SolicitudRecurso
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cod. Proyecto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ProyectoId { get; set; }

        [Display(Name = "Proyecto")]
        public virtual Proyecto Proyecto { get; set; }

        [Display(Name = "Fecha creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Cod. Prioridad")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int PrioridadId { get; set; }

        [Display(Name = "Prioridad")]
        public virtual Prioridad Prioridad { get; set; }

        public Enums.PrioridadType PrioridadType => (Enums.PrioridadType)PrioridadId;

        [Display(Name = "Cod. Estado")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int EstadoId { get; set; }

        [Display(Name = "Estado")]
        public virtual Estado Estado { get; set; }

        public Enums.EstadoType EstadoType => (Enums.EstadoType)EstadoId;

        [Display(Name = "Cod. Responsable")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ResponsableId { get; set; }

        [Display(Name = "Responsable")]
        public virtual Trabajador Responsable { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        public virtual ICollection<SolicitudRecursoDetalle> Recursos { get; set; }
    }
}
