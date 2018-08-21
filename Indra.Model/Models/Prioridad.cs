using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    [Table("Prioridades")]
    public class Prioridad
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Descripción")]
        [StringLength(300, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }

        [Display(Name = "Proyectos")]
        public virtual ICollection<Proyecto> Proyectos { get; set; }

        [Display(Name = "Programas")]
        public virtual ICollection<Programa> Programas { get; set; }

        [Display(Name = "Portafolios")]
        public virtual ICollection<Portafolio> Portafolios { get; set; }

        [Display(Name = "SolicitudesRecurso")]
        public virtual ICollection<SolicitudRecurso> SolicitudesRecurso { get; set; }
    }
}
