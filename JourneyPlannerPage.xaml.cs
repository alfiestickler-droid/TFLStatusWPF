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
using System.Xml;
using TFLStatusWPF.Models;
using TFLStatusWPF.Models.Services;

namespace TFLStatusWPF
{
    /// <summary>
    /// Interaction logic for JourneyPlannerPage.xaml
    /// </summary>
    public partial class JourneyPlannerPage : Page
    {

        private readonly TFLJourneyService _journeyService = new TFLJourneyService();

        private List<StationItem> _allStations = new List<StationItem>();

        public JourneyPlannerPage()
        {
            InitializeComponent();
            //LoadSampleStations();
            LoadAllStationsAsync();
        }

        private async void LoadAllStationsAsync()
        {
            PlanButton.IsEnabled = false;
            SummaryTextBlock.Text = "Loading stations...";

            _allStations = await _journeyService.GetStationsAsync();

            if (_allStations.Count > 0)
            {
                FromStationSelect.ItemsSource = _allStations;
                ToStationSelect.ItemsSource = _allStations;
                SummaryTextBlock.Text = "";
            }
            else
            {
                SummaryTextBlock.Text = "Could not load stations. Check your internet or API key";
            }
            PlanButton.IsEnabled = true;
        }

        // Filters whichever ComboBox the user is currently typing into
        private void StationComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is not ComboBox comboBox) return;

            // If the user just clicked an item from the dropdown, don't re-filter
            if (comboBox.SelectedItem is StationItem selected && selected.Name == comboBox.Text)
                return;

            string searchText = comboBox.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                comboBox.ItemsSource = _allStations;
                    
            }
            else
            {
                comboBox.ItemsSource = _allStations
                    .Where(s => s.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            comboBox.IsDropDownOpen = true;

            if (comboBox.Template.FindName("PART_EditableTextBox", comboBox) is TextBox textBox)
            {
                textBox.CaretIndex = textBox.Text.Length;
            }
        }

        /*private void LoadSampleStations()
        {
            var stations = new List<StationItem>
            {
                new StationItem { Name = "Oxford Circus", Id = "940GZZLUOXC" },
                new StationItem { Name = "Victoria", Id = "940GZZLUVIC" },
                new StationItem { Name = "King's Cross St. Pancras", Id = "940GZZLUKSX" },
                new StationItem { Name = "Waterloo", Id = "940GZZLUWLO" },
                new StationItem { Name = "Liverpool Street", Id = "940GZZLULVT" }
            };

            FromStationSelect.ItemsSource = stations;
            ToStationSelect.ItemsSource = stations;
        }*/

        private async void PlanButton_Click(object sender, RoutedEventArgs e)
        {
            if (FromStationSelect.SelectedValue is not string fromId || ToStationSelect.SelectedValue is not string toId)
            {
                MessageBox.Show("Please select both a start and end station.");
                return;
            }

            if(fromId == toId)
            {
                MessageBox.Show("Start and end stations must be different.");
                return;
            }

            PlanButton.IsEnabled = false;
            SummaryTextBlock.Text = "Calculating route...";
            StepsListBox.ItemsSource = null;

            JourneyResponse? result = await _journeyService.GetJourneyAsync(fromId, toId);

            if (result?.journeys != null && result.journeys.Length > 0)
            {
                var bestJourney = result.journeys.First();

                SummaryTextBlock.Text = $"Total Duration: {bestJourney.duration} mins";
                StepsListBox.ItemsSource = bestJourney.legs;
            }
            else
            {
                SummaryTextBlock.Text = "No route found or API error.";
            }

            PlanButton.IsEnabled = true;
        }

        private void Button_HomeClick(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService != null)
            {
                this.NavigationService.Content = null;
            }
        }
    }
}
