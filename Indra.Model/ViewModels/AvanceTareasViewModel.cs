using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.ViewModels
{
    public class AvanceTareasViewModel
    {
        public string Tarea { get; set; }

        public string Fecha { get; set; }

        public decimal Planificado { get; set; }

        public decimal Actual { get; set; }
    }
}
