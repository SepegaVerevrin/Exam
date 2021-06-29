using System.Data.SqlClient;
using System.Windows;

namespace Electric_trains_app {
    public partial class MainWindow : Window {
        public MainWindow() {
            try {
                InitializeComponent();
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder() {
                    DataSource = @"DESKTOP-52L8N5J\SQLEXPRESS02",
                    InitialCatalog = @"Electric_trains",
                    IntegratedSecurity = true
                };
                Manager.connection = new SqlConnection(builder.ConnectionString);
                MAINFRAME.Navigate(new StartPage());
                Manager.FrameMainWindow = MAINFRAME;
            }
            catch (SqlException error) {
                MessageBox.Show(error.Message);
            }
        }
    }
}
