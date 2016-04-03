//-----------------------------------------------------------------------
// <copyright file="mainwindow.xaml.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/2/2016 4:55 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalog
{
    using MovieCatalog.ViewModel;
    using System.Windows;

    /// <summary>
    /// Interaction logic for <see cref="MainWindow" />.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MainWindow(MovieCatalogViewModel context)
        {
            this.DataContext = context;
            this.InitializeComponent();
        }
    }
}
