using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MovieCatalog.ViewModel
{
    public abstract class ViewModelBase<T> : INotifyPropertyChanged
    {
        private readonly T model;

        protected ViewModelBase(T model)
        {
            if (model.Equals(default(T)))
                throw new ArgumentNullException(); // todo: proper exception message

            this.model = model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected T Model
        {
            get { return this.model; }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;

            if (handler == null)
                return;

            handler(this, e);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
