using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Курсовая_работа.ViewModel;

namespace Курсовая_работа
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            InitializeComponent();
            DataContext = mainWindowViewModel;

            Thread.Sleep(5000);
            mainWindowViewModel.RemoveAt(0);
            Thread.Sleep(5000);
            mainWindowViewModel.RemoveAt(1);
        }
    }
}