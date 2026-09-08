using BetterApex;
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

namespace BetterApex_2
{
    public partial class MainWindow : Window
    {
        private ApexWebSocketClient _apexClient;

        public MainWindow()
        {
            InitializeComponent();

            _apexClient = new ApexWebSocketClient();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _apexClient.ConnectAsync();
        }
    }
}