//-----------------------------------------------------------------------
// <copyright file="moviecatalogviewmodel.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 5:30 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalog.ViewModel
{
    using GalaSoft.MvvmLight.CommandWpf;
    using MovieCatalogService;
    using System.Windows.Input;

    /// <summary>
    /// Represents the view model of an <see cref="MovieCatalogService.IMovieSource" /> instance.
    /// </summary>
    /// <seealso cref="MovieCatalog.ViewModel.ViewModelBase{MovieCatalogService.IMovieSource}" />
    public class MovieCatalogViewModel : ViewModelBase<IMovieSource>
    {
        private readonly ICommand searchCommand;
        private string id;
        private MovieViewModel movie;

        /// <summary>
        /// Initializes a new instance of the <see cref="MovieCatalogViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MovieCatalogViewModel(IMovieSource model)
            : base(model)
        {
            this.searchCommand = new RelayCommand(() => this.Search(this.id), () => !string.IsNullOrWhiteSpace(this.id));
        }

        /// <summary>
        /// Gets the search command.
        /// </summary>
        public ICommand SearchCommand
        {
            get { return this.searchCommand; }
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
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

        /// <summary>
        /// Gets the result movie.
        /// </summary>
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
