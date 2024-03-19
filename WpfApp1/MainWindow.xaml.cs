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
using static WpfApp1.GlobalVariables;

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
            bool bRead = g_DB.SelectData("ID, Name, CountryCode, District, Population", "city", "CountryCode = 'KOR'");
            foreach (DataRow dr in g_DB.ds.Tables[0].Rows)
            {
                int iCol = 0;
                lstNames.Items.Add($"{dr[iCol++]}_{dr[iCol++]}_{dr[iCol++]}_{dr[iCol++]}_{dr[iCol++]}");
            }
        }
    }
}
