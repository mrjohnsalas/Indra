using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Indra.Model.ViewModels;

namespace Indra.Model.Models
{
    [Table("Portafolios")]
    public class Portafolio
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Num. Portafolio")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string NumPortafolio { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(300, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }

        [Display(Name = "Fecha creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Fecha modificación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EditDate { get; set; }

        [Display(Name = "Cod. Categoria Componente")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int CategoriaComponenteId { get; set; }

        [Display(Name = "Categoria Componente")]
        public CategoriaComponente CategoriaComponente { get; set; }

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

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Remark { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string UserId { get; set; }

        [Display(Name = "Programas")]
        public virtual ICollection<PortafolioDetallePrograma> Programas { get; set; }

        [Display(Name = "Proyectos")]
        public virtual ICollection<PortafolioDetalleProyecto> Proyectos { get; set; }

        public virtual ICollection<PropuestaBalanceo> PropuestaBalanceos { get; set; }

        [NotMapped]
        public List<PropuestaBalanceoDetalleView> PropuestaBalanceoDetalleViews { get; set; }
    }
}