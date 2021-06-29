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
    public partial class StopsPage : Page {
        public class Stops { 
            public string station { get; set; }
            public string addres { get; set; }
            public int type_platform_id { get; set; }
        }
        public StopsPage() {
            InitializeComponent();
            List<Stops> StopsList = new List<Stops>();
            Manager.connection.Close();
            Manager.connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Stops", Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Stops tmp = new Stops();
                    tmp.station = reader[0].ToString();
                    tmp.addres = reader[1].ToString();
                    tmp.type_platform_id = reader.GetInt32(2);
                    StopsList.Add(tmp);
                }
                StopsGrid.ItemsSource = StopsList;
            }
            Manager.connection.Close();
        }

        private void ComeBack(object sender, System.Windows.RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new StartPage());
        }

    }
}
