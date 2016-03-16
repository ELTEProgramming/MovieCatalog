using GalaSoft.MvvmLight.Command;
using MovieCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieCatalog.ViewModel
{
    public class MovieCatalogViewModel : ViewModelBase<IMovieSource>
    {
        private readonly ICommand searchCommand;
        private string id;
        private MovieViewModel movie;

        public MovieCatalogViewModel(IMovieSource model)
            : base(model)
        {
            this.searchCommand = new RelayCommand(() => this.Search(this.id)/*, () => !string.IsNullOrWhiteSpace(this.id)*/); // todo: canExecute
        }

        public ICommand SearchCommand
        {
            get { return this.searchCommand; }
        }

        public string Id
        {
            get { return this.id; }
            set
            {
                if (this.id == value)
                    return;

                this.id = value;
                this.OnPropertyChanged();
            }
        }

        public MovieViewModel Movie
        {
            get { return this.movie; }
            private set
            {
                if (this.movie == value)
                    return;

                this.movie = value;
                this.OnPropertyChanged();
            }
        }

        private void Search(string id)
        {
            var result = this.Model.GetMovieById(id);
            this.Movie = result == null ? null : new MovieViewModel(result);
        }
    }
}
