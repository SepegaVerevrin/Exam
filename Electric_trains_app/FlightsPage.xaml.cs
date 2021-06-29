using System.Windows.Controls;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Electric_trains_app {

    public partial class FlightsPage : Page {
        public class Flight {
            public  int train_id { get; set; }
            public  string station_start { get; set; }
            public  int count_cars { get; set; }
            public  int type_train_id { get; set; }
        }
        public FlightsPage() {
            InitializeComponent();
            List<Flight> FlightList = new List<Flight>();
            Manager.connection.Close();
            Manager.connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Flights", Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Flight tmp = new Flight();
                    tmp.train_id = reader.GetInt32(0);
                    tmp.station_start = reader[1].ToString();
                    tmp.count_cars = reader.GetInt32(2);
                    tmp.type_train_id = reader.GetInt32(3);
                    FlightList.Add(tmp);
                }
                FlightsGrid.ItemsSource = FlightList;
            }
            Manager.connection.Close();
        }

        private void ComeBack(object sender, System.Windows.RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new StartPage());
        }

        private void Add(object sender, System.Windows.RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new AddFlight());
        }
    }
}
