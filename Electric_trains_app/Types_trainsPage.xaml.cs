using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;

namespace Electric_trains_app {
    public partial class Types_trainsPage : Page {
        public class Types_trains {
            public int type_train_id { get; set; }
            public string type_train_name { get; set; }
        }
        public Types_trainsPage() {
            InitializeComponent();
            List<Types_trains> Types_trainsList = new List<Types_trains>();
            Manager.connection.Close();
            Manager.connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Types_trains", Manager.connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows) {
                while (reader.Read()) {
                    Types_trains tmp = new Types_trains();
                    tmp.type_train_id = reader.GetInt32(0);
                    tmp.type_train_name = reader[1].ToString();
                    Types_trainsList.Add(tmp);
                }
                Types_trainsGrid.ItemsSource = Types_trainsList;
            }
            Manager.connection.Close();
        }
        private void ComeBack(object sender, System.Windows.RoutedEventArgs e) {
            Manager.FrameMainWindow.Navigate(new StartPage());
        }
    }
}
