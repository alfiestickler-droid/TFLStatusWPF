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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            List<TubeLine>? tubeLines = await TFLStatus.TFL();

            Bakerloo.Content = tubeLines[0].Name;
            Central.Content = tubeLines[1].Name;
            Circle.Content = tubeLines[2].Name;
            District.Content = tubeLines[3].Name;
            HammersmithAndCity.Content = tubeLines[4].Name;
            Jubilee.Content = tubeLines[5].Name;
            Metropolitan.Content = tubeLines[6].Name;
            Northern.Content = tubeLines[7].Name;
            Piccadilly.Content = tubeLines[8].Name;
            Victoria.Content = tubeLines[9].Name;
            WaterlooAndCity.Content = tubeLines[10].Name;

        }
    }
}