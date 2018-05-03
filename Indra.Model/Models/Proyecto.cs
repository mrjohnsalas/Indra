using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class Proyecto
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Num. Proyecto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string NumProyecto { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }

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

        [Display(Name = "Cod. Sts. Aprobación")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int EstadoAprobacionId { get; set; }

        [Display(Name = "Sts. Aprobación")]
        public virtual EstadoAprobacion EstadoAprobacion { get; set; }

        public EstadoAprobacionType EstadoAprobacionType => (EstadoAprobacionType) EstadoAprobacionId;
        
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

        [Display(Name = "Cod. Cliente")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }

        [Display(Name = "Cod. Tipo Proyecto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int TipoProyectoId { get; set; }

        [Display(Name = "Tipo Proyecto")]
        public virtual TipoProyecto TipoProyecto { get; set; }

        public TipoProyectoType TipoProyectoType => (TipoProyectoType)TipoProyectoId;

        [Display(Name = "Cod. Responsable")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ResponsableId { get; set; }

        [Display(Name = "Responsable")]
        public virtual Trabajador Responsable { get; set; }

        [Display(Name = "Cod. Patrocinador")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int PatrocinadorId { get; set; }

        [Display(Name = "Patrocinador")]
        public virtual Patrocinador Patrocinador { get; set; }
    }
}