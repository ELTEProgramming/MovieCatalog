//-----------------------------------------------------------------------
// <copyright file="viewmodelbase.cs" company="ELTE">
//     Copyright (c) ELTE All rights reserved.
// </copyright>
// <author>kornel.katai</author>
// <date>3/16/2016 5:21 PM</date>
//-----------------------------------------------------------------------

namespace MovieCatalog.ViewModel
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents the abstract base class for view models.
    /// </summary>
    /// <typeparam name="T">Type of the model.</typeparam>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModelBase<T> : INotifyPropertyChanged
    {
        private readonly T model;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase{T}"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <exception cref="System.ArgumentNullException">Model cannot be null.</exception>
        protected ViewModelBase(T model)
        {
            if (model.Equals(default(T)))
                throw new ArgumentNullException(); // todo: proper exception message

            this.model = model;
        }

        /// <summary>
        /// Occurs when a property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the model.
        /// </summary>
        protected T Model
        {
            get { return this.model; }
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;

            if (handler == null)
                return;

            handler(this, e);
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyChanged" /> event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
