using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Presenters
{
    public class BeerDetailViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Alcohol { get; set; }
        public string? Color { get; set; }
        public string? Style { get; set; }
        public string? Msg { get; set; }
    }
}
