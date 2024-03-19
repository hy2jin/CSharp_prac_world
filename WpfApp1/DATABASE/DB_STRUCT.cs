using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp1.GlobalVariables;

namespace WpfApp1.DATABASE
{
    public class DB_TABLE_City
    {
        public DB_TABLE_City() {
            Reset();
        }

        ~DB_TABLE_City() {}

        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public int Population { get; set; }

        public void Reset()
        {
            ID = 0;
            Name = string.Empty;
            CountryCode = string.Empty;
            District = string.Empty;
            Population = 0;
        }
    }

    public static class DB_DATA_List
    {
        public static List<DB_TABLE_City> arrTable_City = new List<DB_TABLE_City>();
    }
    
    public static class SelectDB
    {
        public static void City_KOR()
        {
            bool bRead = g_DB.SelectData("ID, Name, CountryCode, District, Population", "city", "CountryCode = 'KOR'");
            foreach (DataRow dr in g_DB.ds.Tables[0].Rows)
            {
                DB_TABLE_City TempCity = new DB_TABLE_City();
                TempCity.Reset();
                int iCol = 0;

                TempCity.ID = (int)dr[iCol++];
                TempCity.Name = (string)dr[iCol++];
                TempCity.CountryCode = (string)dr[iCol++];
                TempCity.District = (string)dr[iCol++];
                TempCity.Population = (int)dr[iCol++];

                DB_DATA_List.arrTable_City.Add(TempCity);
            }
        }
    }
}
