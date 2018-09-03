using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class LineDataSet<T, Y>
    {
        public string label { get; set; }

        public List<KeyValuePair<T, Y>> data { get; set; }

        public string color { get; set; }

        public int value0 { get; set; }

        public decimal value1 { get; set; }

        public string value2 { get; set; }

        public decimal value3 { get; set; }
    }
}