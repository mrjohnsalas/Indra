using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class AlmacenRecurso
    {
        [Key]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cod. Almacen")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int AlmacenId { get; set; }

        [Display(Name = "Almacen")]
        public virtual Almacen Almacen { get; set; }

        [Display(Name = "Cod. Recurso")]
        [Required(ErrorMessage = "Debes ingresar {0}")]
        public int RecursoId { get; set; }

        [Display(Name = "Recurso")]
        public virtual Recurso Recurso { get; set; }

        [Display(Name = "Stock")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Stock { get; set; }

        [Display(Name = "Stock Comprometido")]
        [Required(ErrorMessage = "You must enter {0}")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal StockCommitted { get; set; }

        [Display(Name = "Stock Disponible")]
        [DisplayFormat(DataFormatString = "{0:N3}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal StockAvailable => Stock - StockCommitted;
    }
}