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
            
            List<string>? lineStatus = await TFLTubeInfo.TFLTubeStatus();
            List<string>? lineReason = await TFLTubeInfo.TFLTubeDescriptions();


            BakerlooStatus.Content = lineStatus[0];
            CentralStatus.Content = lineStatus[1];
            CircleStatus.Content = lineStatus[2];
            DistrictStatus.Content = lineStatus[3];
            HammersmithAndCityStatus.Content = lineStatus[4];
            JubileeStatus.Content = lineStatus[5];
            MetropolitanStatus.Content = lineStatus[6];
            NorthernStatus.Content = lineStatus[7];
            PiccadillyStatus.Content = lineStatus[8];
            VictoriaStatus.Content = lineStatus[9];
            WaterlooAndCityStatus.Content = lineStatus[10];


            BakerlooReason.Text = lineReason[0];
            CentralReason.Text = lineReason[1];
            CircleReason.Text = lineReason[2];
            DistrictReason.Text = lineReason[3];
            HammersmithAndCityReason.Text = lineReason[4];
            JubileeReason.Text = lineReason[5];
            MetropolitanReason.Text = lineReason[6];
            NorthernReason.Text = lineReason[7];
            PiccadillyReason.Text = lineReason[8];
            VictoriaReason.Text = lineReason[9];
            WaterlooAndCityReason.Text = lineReason[10];
        }

        private void Button_FactClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}