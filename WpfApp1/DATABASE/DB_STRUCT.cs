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
        public DB_TABLE_City() { Reset(); }

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
    public class DB_TABLE_CountryCode
    {
        public DB_TABLE_CountryCode() { Reset(); }
        ~DB_TABLE_CountryCode() { }
        
        public string Code { get; set; }
        public string Name { get; set; }

        public void Reset()
        {
            Code = string.Empty;
            Name = string.Empty;
        }
    }

    public static class DB_DATA_List
    {
        public static List<DB_TABLE_City> arrTable_City = new List<DB_TABLE_City>();
        public static List<DB_TABLE_City> arrInsert_City = new List<DB_TABLE_City>();
        public static List<DB_TABLE_CountryCode> arrTable_CountryCode = new List<DB_TABLE_CountryCode>();
    }
    
    public static class SelectDB
    {
        public static void City_KOR()
        {
            bool bRead = g_DB.SelectData("ID, Name, CountryCode, District, Population", "city", "CountryCode = 'KOR'");
            DB_DATA_List.arrTable_City.Clear();

            foreach (DataRow dr in g_DB.ds.Tables[0].Rows)
            {
                DB_TABLE_City TempData = new DB_TABLE_City();
                TempData.Reset();
                int iCol = 0;

                TempData.ID = (int)dr[iCol++];
                TempData.Name = (string)dr[iCol++];
                TempData.CountryCode = (string)dr[iCol++];
                TempData.District = (string)dr[iCol++];
                TempData.Population = (int)dr[iCol++];

                DB_DATA_List.arrTable_City.Add(TempData);
            }
        }
        public static void CountryCode()
        {
            bool bRead = g_DB.SelectData("SELECT Code, Name FROM country ORDER BY Name");
            DB_DATA_List.arrTable_CountryCode.Clear();

            foreach (DataRow dr in g_DB.ds.Tables[0].Rows)
            {
                DB_TABLE_CountryCode TempData = new DB_TABLE_CountryCode();
                TempData.Reset();
                int iCol = 0;

                TempData.Code = (string)dr[iCol++];
                TempData.Name = (string)dr[iCol++];

                DB_DATA_List.arrTable_CountryCode.Add(TempData);
            }
    }

    public static class UpdateDB
    {
        public static void City_KOR(string val)
        {
            string whereMsg = $"Name = '{val}'";
            bool bUpdate = g_DB.UpdateData("city", "Population = 12", whereMsg);
        }
    }

    public static class DeleteDB
    {
        public static bool City_KOR(string val)
        {
            string whereMsg = $"Name = '{val}'";
            bool bDelete = g_DB.DeleteData("city", whereMsg);
            return bDelete;
        }
    }
}
