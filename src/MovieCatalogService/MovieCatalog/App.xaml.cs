//-----------------------------------------------------------------------
// <copyright file="app.xaml.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/2/2016 4:55 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalog
{
    using Microsoft.Practices.Unity;
    using System.Windows;

    /// <summary>
    /// Interaction logic for this application.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The main entry point of this application.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="StartupEventArgs"/> instance containing the event data.</param>
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            using (var container = MovieCatalogContainer.GenerateContainer())
                (this.MainWindow = container.Resolve<MainWindow>()).Show();
        }
    }
}
