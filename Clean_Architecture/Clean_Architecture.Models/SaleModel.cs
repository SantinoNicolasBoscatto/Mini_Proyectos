using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Models
{
    public class SaleModel
    {
        public decimal Total { get; set; }
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public List<ConceptModel> Concepts { get; set; }
    }
}
