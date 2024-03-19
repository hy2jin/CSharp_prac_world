using System;
using System.Collections.Generic;
using System.Data;
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
using WpfApp1.DATABASE;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTestDB_Click(object sender, RoutedEventArgs e)
        {
            SelectDB.City_KOR();
            int tot = DB_DATA_List.arrTable_City.Count;
            for (int i = 0; i < tot; i++)
            {
                string nn = DB_DATA_List.arrTable_City[i].Name;
                lstNames.Items.Add(nn);
            }
        }
    }
}
