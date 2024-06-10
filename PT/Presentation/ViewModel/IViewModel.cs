using Presentation.Model.API;
using System.ComponentModel;

namespace Presentation.ViewModel
{
    public abstract class IViewModel : INotifyPropertyChanged
    {
        public static IErrorInformer Informer;

        public IViewModel SelectedViewModel;

        public IViewModel Parent { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
