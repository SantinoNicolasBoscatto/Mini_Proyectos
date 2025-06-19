using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Presenters
{
    public class BeerDetailPresenter : IPresenter<Beer, BeerDetailViewModel>
    {
        public IEnumerable<BeerDetailViewModel> Present(IEnumerable<Beer> data)
        {
            var details = data.Select(x => new BeerDetailViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Alcohol = x.Alcohol.ToString(),
                        Color = x.IsStrongBeer()? "red" : "green",
                        Style = x.Style,
                        Msg = x.IsStrongBeer()? "Hojaldre" : ""
                    });
            return details;
        }
    }
}
