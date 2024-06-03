using Presentation.ViewModel;
using System.Windows.Controls;

namespace Presentation.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            this.DataContext = new HomeViewModel();
        }

        private void startButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
