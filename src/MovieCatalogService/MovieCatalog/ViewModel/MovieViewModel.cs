//-----------------------------------------------------------------------
// <copyright file="movieviewmodel.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 5:20 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalog.ViewModel
{
    using MovieCatalogService;

    /// <summary>
    /// Represents the view model of a <see cref="MovieCatalogService.Movie" /> instance.
    /// </summary>
    /// <seealso cref="MovieCatalog.ViewModel.ViewModelBase{MovieCatalogService.Movie}" />
    public class MovieViewModel : ViewModelBase<Movie>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovieViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MovieViewModel(Movie model)
            : base(model)
        {
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public string Id
        {
            get { return this.Model.Id; }
        }

        /// <summary>
        /// Gets the title.
        /// </summary>
        public string Title
        {
            get { return this.Model.Title; }
        }
    }
}
