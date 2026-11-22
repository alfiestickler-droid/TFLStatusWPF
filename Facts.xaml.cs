using System;
using System.Collections.Generic;
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

namespace TFLStatusWPF
{
    /// <summary>
    /// Interaction logic for Facts.xaml
    /// </summary>
    public partial class Facts : Page
    {
        public Facts()
        {
            InitializeComponent();
        }

        //Home Button

        private void Button_HomeClick(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Content = null;
            }
        }

        //Get Fact Button
        private void Button_FactClick(object sender, RoutedEventArgs e)
        {
            FactBox.Visibility = Visibility.Visible;
            RndFact.Text = TubeFacts.GetRandomFact();
        }
    }
}
