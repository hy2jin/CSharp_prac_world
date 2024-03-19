using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1.DATABASE
{
    public class ImDB
    {
        private string SERVER = "localhost";       //DB 서버 주소
        private int PORT = 3306;                   //DB 서버 포트
        private string DATABASE = "world";         //DB 이름(스키마)
        private string DB_ID = "lee";                 //계정 아이디
        private string DB_PWD = "leeleelee";          //계정 비밀번호
        private bool DB_CONN = false;

        private string connAddr = "";

        public MySqlConnection conn { get; private set; } // MySqlConnection 인스턴스를 외부에서 접근할 수 있도록 함

        public ImDB()
        {
        }

        public ImDB(string serv, int port, string db, string id, string pwd)
        {
            this.SERVER = serv;
            this.PORT = port;
            this.DATABASE = db;
            this.DB_ID = id;
            this.DB_PWD = pwd;
        }

        public bool DBConnection()
        {
            connAddr = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", this.SERVER, this.PORT, this.DATABASE, this.DB_ID, this.DB_PWD);

            // MySqlConnection 인스턴스 생성
            conn = new MySqlConnection(connAddr);

            conn.Open();
            this.DB_CONN = conn.Ping();

            if (this.DB_CONN)
                Console.WriteLine("Success DB Connection");
            else
                Console.WriteLine("Fail DB Connection");

            return this.DB_CONN;
        }

        public void SelectData(string sel, string tb, string wh)
        {
            string sqlQuery = $"SELECT {sel} FROM {tb} WHERE {wh};";
            SelectData(sqlQuery);
        }
        public void SelectData(string sel, string tb)
        {
            string sqlQuery = $"SELECT {sel} FROM {tb};";
            SelectData(sqlQuery);
        }
        public void SelectData(string query)
        {
            try
            {
                DataSet ds = new DataSet();
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(ds, "members");
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(dr["name"]);
                    }
                }
                int bac = 23;
            }
            catch
            {

            }
        }

        public string strSelectData(string query)
        {
            //bool connResult = DBConnection();
            string result = "";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    result = Convert.ToString(rdr["Address"]);
                }
                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
                conn.Close();
                result = "Fail SelectData";
                return result;

            }
        }
    }
}
