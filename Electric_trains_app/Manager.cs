using System.Data.SqlClient;
using System.Windows.Controls;

namespace Electric_trains_app {
    class Manager {
        public static Frame FrameMainWindow { get; set; } 
        public static SqlConnection connection { get; set; } 
    }
}
