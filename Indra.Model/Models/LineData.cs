using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indra.Model.Models
{
    public class LineData<T, Y>
    {
        public string label { get; set; }

        public List<KeyValuePair<T, Y>> data { get; set; }

        public string color { get; set; }
    }
}
