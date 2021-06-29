using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Electric_trains_app {
    public class Flight_stop {
        public string station { get; set; }
        public int train_id { get; set; }
        public string arrival { get; set; }
        public string departure { get; set; }

    }
    public partial class Flights_stopsPage : Page {
        public Flights_stopsPage() {
            InitializeComponent();
            List<Flight_stop> Flight_stopList = new List<Flight_stop>();
            Manager.connection.Close();
            Manager.connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Flights_stops", Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Flight_stop tmp = new Flight_stop();
                    tmp.station = reader[0].ToString();
                    tmp.train_id = reader.GetInt32(1);
                    tmp.arrival = reader[2].ToString();
                    tmp.departure = reader[3].ToString();
                    Flight_stopList.Add(tmp);
                }
                Flights_stopsGrid.ItemsSource = Flight_stopList;
            }
            Manager.connection.Close();


        }
        private void ComeBack(object sender, System.Windows.RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new StartPage());
        }
    }
}
