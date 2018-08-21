using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    [Table("Documentos")]
    public class Documento
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Num. Documento")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        [StringLength(25, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 1)]
        public string NumDocument { get; set; }

        [Display(Name = "Nombre de archivo")]
        [StringLength(100, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 2)]
        public string FileName { get; set; }

        public string FullFileName => $"{FileName}{FileExtension}";

        [Display(Name = "Extensión de archivo")]
        [StringLength(10, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 2)]
        public string FileExtension { get; set; }

        public string FileExtensionWithoutDot => FileExtension.Replace(".", string.Empty);

        [Display(Name = "Content Type")]
        [StringLength(300, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres", MinimumLength = 2)]
        public string ContentType { get; set; }

        [Display(Name = "Documento")]
        public byte[] Content { get; set; }

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

        [Display(Name = "Fecha creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Fecha modificación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EditDate { get; set; }

        [Display(Name = "Cod. Portafolio")]
        public int? PortafolioId { get; set; }

        [Display(Name = "Portafolio")]
        public virtual Portafolio Portafolio { get; set; }
    }
}