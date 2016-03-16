using MovieCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModel
{
    public class MovieViewModel : ViewModelBase<Movie>
    {
        public MovieViewModel(Movie model)
            : base(model)
        {
        }

        public string Id
        {
            get { return this.Model.Id; }
        }

        public string Title
        {
            get { return this.Model.Title; }
        }
    }
}
