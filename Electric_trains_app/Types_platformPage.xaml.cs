using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Electric_trains_app {
    public partial class Types_platformPage : Page {
        public class Types_platform {
            public int type_platform_id { get; set; }
            public string type_platform_name { get; set; }
        }
        public Types_platformPage() {
            InitializeComponent();
            List<Types_platform> Types_platformList = new List<Types_platform>();
            Manager.connection.Close();
            Manager.connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Types_platforms", Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Types_platform tmp = new Types_platform();
                    tmp.type_platform_id = reader.GetInt32(0);
                    tmp.type_platform_name = reader[1].ToString();
                    Types_platformList.Add(tmp);
                }
                Types_platformGrid.ItemsSource = Types_platformList;
            }
            Manager.connection.Close();

            

        }
        private void ComeBack(object sender, System.Windows.RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new StartPage());
        }
    }
}
