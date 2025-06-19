using Clean_Architecture.Application;
using Clean_Architecture.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Presenters
{
    // La implementacion de Presenter, El metodo se encargara de formatear la Entity a ViewModel.
    public class BeerPresenter : IPresenter<Beer, BeerViewModel>
    {
        // Los formateos de informacion lo haremos aqui
        public IEnumerable<BeerViewModel> Present(IEnumerable<Beer> data)
        {
            return data.Select(x => new BeerViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Alcohol = x.Alcohol + "%"
            });
        }
    }
}
