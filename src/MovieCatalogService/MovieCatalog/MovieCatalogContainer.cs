//-----------------------------------------------------------------------
// <copyright file="moviecatalogcontainer.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/30/2016 5:11 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalog
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// Represents the application bootstrapper container.
    /// </summary>
    internal static class MovieCatalogContainer
    {
        /// <summary>
        /// Generates the container.
        /// </summary>
        /// <returns>The container.</returns>
        public static IUnityContainer GenerateContainer()
        {
            return new UnityContainer().LoadConfiguration();
        }
    }
}
