﻿using System.ComponentModel.DataAnnotations;

namespace Indra.Model.Models
{
    public class ProgramaDetalle
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cod. Programa")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ProgramaId { get; set; }

        [Display(Name = "Programa")]
        public virtual Programa Programa { get; set; }

        [Display(Name = "Cod. Proyecto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int ProyectoId { get; set; }

        [Display(Name = "Proyecto")]
        public virtual Proyecto Proyecto { get; set; }
    }
}