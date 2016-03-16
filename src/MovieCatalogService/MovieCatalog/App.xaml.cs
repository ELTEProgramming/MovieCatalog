using MovieCatalog.ViewModel;
using MovieCatalogService.OmdbSource;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MovieCatalog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            this.MainWindow = new MainWindow
            {
                DataContext = new MovieCatalogViewModel(new OmdbMovieSource())
            };

            this.MainWindow.Show();
        }
    }
}
