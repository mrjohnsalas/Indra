using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }

        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string RazonSocial { get; set; }

        [Display(Name = "Nro. Documento")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(11, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 11)]
        public string NroDocumento { get; set; }

        [Display(Name = "Cod. Doc. Identidad")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int TipoDocumentoIdentidadId { get; set; }

        [Display(Name = "Tipo Doc. Identidad")]
        public virtual TipoDocumentoIdentidad TipoDocumentoIdentidad { get; set; }

        public TipoDocumentoIdentidadType TipoDocumentoIdentidadType => (TipoDocumentoIdentidadType)TipoDocumentoIdentidadId;

        [Display(Name = "Teléfono")]
        [StringLength(9, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 7)]
        public string Telefono { get; set; }

        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Email { get; set; }

        [Display(Name = "Sitio Web")]
        [DataType(DataType.Url)]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string WebSite { get; set; }

        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string ContactName { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(250, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string Direccion { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
