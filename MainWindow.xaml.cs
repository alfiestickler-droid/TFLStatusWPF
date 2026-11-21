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
            List<TubeLine>? tubeLines = await TFLTubeInfo.TFLTubeNames();
            List<string>? lineStatus = await TFLTubeInfo.TFLTubeStatus();


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



        }
    }
}