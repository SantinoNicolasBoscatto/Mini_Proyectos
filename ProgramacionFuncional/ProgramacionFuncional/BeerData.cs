using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramacionFuncional
{
    public class BeerData
    {
        private List<string> beers;
        public BeerData()
        {
            this.beers = new List<string>();
        }

        public void Add(string beer) => beers.Add(beer);

        public List<string> GetBeers() => beers;
    }

    public class BeerFormat
    {
        public List<string> GetBeersFormateado(List<string> beers)
        {
            var data = new List<string>();
            foreach (var beer in beers)
            {
                data.Add("Cerveza: " + beer);
            }
            return data;
        }
    }


    public static class ReportManager
    {
        public static void SaveReport(string filepath, List<string> list)
        {
            using (var writer = new StreamWriter(filepath))
            {
                foreach (var beer in list)
                {
                    writer.WriteLine(beer);
                }
            }
        }
    }
}
