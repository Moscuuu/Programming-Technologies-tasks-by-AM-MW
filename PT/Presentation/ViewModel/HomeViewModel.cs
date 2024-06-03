using System.Windows.Input;

namespace Presentation.ViewModel
{
    internal class HomeViewModel : IViewModel
    {
        public ICommand StartAppCommand { get; set; }

        public ICommand ExitAppCommand { get; set; }

        public HomeViewModel()
        {
            this.StartAppCommand = new SwitchViewCommand("UserMasterView");

            this.ExitAppCommand = new CloseApplicationCommand();
        }
    }
}
