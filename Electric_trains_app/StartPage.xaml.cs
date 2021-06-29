using System.Windows;
using System.Windows.Controls;


namespace Electric_trains_app {

    public partial class StartPage : Page {
        public StartPage() {
            InitializeComponent();
        }

        private void Flights_Button_Click(object sender, RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new FlightsPage());
        }

        private void Stops_Button_Click(object sender, RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new StopsPage());
        }

        private void Flights_stops_Button_Click(object sender, RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new Flights_stopsPage());
        }

        private void Types_trains_Button_Click(object sender, RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new Types_trainsPage());
        }

        private void Types_platform_Button_Click(object sender, RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new Types_platformPage());
        }
    }
}
