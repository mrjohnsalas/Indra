﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    [Table("Patrocinadores")]
    public class Patrocinador
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Nombres { get; set; }

        [Display(Name = "Apellido paterno")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string ApellidoPaterno { get; set; }

        [Display(Name = "Apellido materno")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string ApellidoMaterno { get; set; }

        [Display(Name = "Nombre completo")]
        public string FullName => $"{ApellidoPaterno} {ApellidoMaterno}, {Nombres}";

        [Display(Name = "Nombre corto")]
        public string ShortName => $"{ApellidoPaterno}, {Nombres}";

        [Display(Name = "Nro. Documento")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(8, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 8)]
        public string NroDocumento { get; set; }

        [Display(Name = "Cod. Doc. Identidad")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int TipoDocumentoIdentidadId { get; set; }

        [Display(Name = "Tipo Doc. Identidad")]
        public virtual TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }

        public Enums.TipoDocumentoIdentidadType TipoDocumentoIdentidadType => (Enums.TipoDocumentoIdentidadType)TipoDocumentoIdentidadId;

        [Display(Name = "Teléfono")]
        [StringLength(9, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 7)]
        public string Telefono { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Email { get; set; }

        [Display(Name = "Proyectos")]
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
