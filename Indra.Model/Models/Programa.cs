using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indra.Model.Models
{
    [Table("Programas")]
    public class Programa
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Num. Programa")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string NumPrograma { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        [NotMapped]
        [Display(Name = "Num With Name")]
        public string NumAndName => $"{NumPrograma} - {Name}";

        [Display(Name = "Descripción")]
        [StringLength(300, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }

        [Display(Name = "Presupuesto")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Presupuesto { get; set; }

        [Display(Name = "Fecha inicial")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StarDate { get; set; }

        [Display(Name = "Fecha final")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FinalDate { get; set; }

        [Display(Name = "Cod. Prioridad")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int PrioridadId { get; set; }

        [Display(Name = "Prioridad")]
        public virtual Prioridad Prioridad { get; set; }

        public PrioridadType PrioridadType => (PrioridadType)PrioridadId;

        [Display(Name = "Cod. Estado")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int EstadoId { get; set; }

        [Display(Name = "Estado")]
        public virtual Estado Estado { get; set; }

        public EstadoType EstadoType => (EstadoType)EstadoId;

        [Display(Name = "Cod. Responsable")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ResponsableId { get; set; }

        [Display(Name = "Responsable")]
        public virtual Trabajador Responsable { get; set; }

        [Display(Name = "Proyectos")]
        public virtual ICollection<ProgramaDetalle> Proyectos { get; set; }

        //public virtual ICollection<PortafolioDetallePrograma> PortafolioDetalleProgramas { get; set; }
    }
}
