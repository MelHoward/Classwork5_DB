using System;
using System.Collections.Generic;
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
using System.Data.OleDb;

namespace Classwork5_DB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;

        public MainWindow()
        {
            string connectStr =  "Provider=Microsoft.Jet.OLEDB.4.0;" +
                                 "Data Source=|DataDirectory|\\Classwork5.mdb;" +
                                 "User ID=admin";

            cn = new OleDbConnection(connectStr);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += read[0].ToString() + "\t" + 
                        read[1].ToString() + "  " + read[2] + "\n" ;
            }
            ShowText.Text = data;
            cn.Close();
        }

        private void ViewEmployees_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Employees";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";

            while (read.Read())
            {
                data += read[0].ToString() + "\t" +
                        read[1] + " " + read[2] + "\n";
            }
            ShowText.Text = data;
            cn.Close();
        }
    }
}
