using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Domain
{
    public class Sale
    {

        public int Id { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; }
        public List<Concept> Concepts { get; }

        public Sale(DateTime date, List<Concept> concepts)
        {
            Date = date;
            Concepts = concepts;
            Total = GetTotal();
        }
        private decimal GetTotal() => Concepts.Sum(x => x.Price);
    }
}
