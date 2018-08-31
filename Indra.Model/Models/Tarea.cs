using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class Tarea
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Orden")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int Index { get; set; }

        [Display(Name = "Cod. Tipo Duración")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int TipoDuracionId { get; set; }

        [Display(Name = "Tipo Duración")]
        public virtual TipoDuracion TipoDuracion { get; set; }

        public Enums.TipoDuracionType TipoDuracionType => (Enums.TipoDuracionType)TipoDuracionId;

        [Display(Name = "Duración")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Duracion { get; set; }

        [Display(Name = "Fecha inicial")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StarDate { get; set; }

        [Display(Name = "Fecha final")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FinalDate { get; set; }

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

        [Display(Name = "Cod. Proyecto")]
        public int ProyectoId { get; set; }

        [Display(Name = "Proyecto")]
        public virtual Proyecto Proyecto { get; set; }

        [Display(Name = "Porcentaje")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [NotMapped]
        public decimal Porcentaje { get; set; }

        [Display(Name = "Progreso")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [NotMapped]
        public decimal Progreso { get; set; }
    }
}