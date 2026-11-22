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
using TFLStatusWPF.Tfl_updates;

namespace TFLStatusWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        //Get Status Page Button
        private void Button_StatusPageClick(object sender, RoutedEventArgs e)
        {
            GetStatusPage.Navigate(new Statuses());
        }


        //Get Fact Button
        private void Button_FactClick(object sender, RoutedEventArgs e)
        {
            FactBox.Visibility = Visibility.Visible;
            RndFact.Text = TubeFacts.GetRandomFact();
        }
    }
}