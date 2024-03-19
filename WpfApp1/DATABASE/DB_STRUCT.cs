using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class DB_DATA_List
    {
        public List<DB_TABLE_City> arrTable_City;
        public DB_DATA_List()
        {
            arrTable_City = new List<DB_TABLE_City>();
        }
    }
    
}
