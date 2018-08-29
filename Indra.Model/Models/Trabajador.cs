using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    [Table("Trabajadores")]
    public class Trabajador : Patrocinador
    {
        public virtual ICollection<Programa> Programas { get; set; }

        public virtual ICollection<Portafolio> Portafolios { get; set; }

        public virtual ICollection<SolicitudRecurso> SolicitudRecursos { get; set; }

        public virtual ICollection<Documento> Documentos { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}