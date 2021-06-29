using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Electric_trains_app {

    public partial class AddFlight : Page {
        public AddFlight() {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e) {
            Manager.connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Flights (train_id,station_start,count_cars,type_train_id) VALUES " +
            " ((SELECT MAX(train_id) + 1 AS FlightsMax FROM Flights),@station_start,@count_cars,@type_train_id)", Manager.connection);
            SqlParameter station_start = new SqlParameter("@station_start", Station_start_TB.Text); command.Parameters.Add(station_start);
            SqlParameter count_cars = new SqlParameter("@count_cars", Count_cars_TB.Text); command.Parameters.Add(count_cars);
            SqlParameter type_train_id = new SqlParameter("@type_train_id", type_train_id_TB.Text); command.Parameters.Add(type_train_id);
            command.ExecuteNonQuery();
            Manager.connection.Close();
            MessageBox.Show("Данные добавлены");
            Manager.FrameMainWindow.Navigate(new StartPage());
        }
    }
}
