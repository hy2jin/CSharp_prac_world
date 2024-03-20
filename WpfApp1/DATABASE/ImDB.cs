using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace WpfApp1.DATABASE
{
    public class ImDB
    {
        private string SERVER = "localhost";        //DB 서버 주소
        private string DATABASE = "world";          //DB 이름(스키마)
        private string DB_ID = "lee";               //계정 아이디
        private string DB_PWD = "leeleelee";        //계정 비밀번호
        private int PORT = 3306;                    //DB 서버 포트
        private bool DB_CONN = false;

        private string connAddr = "";

        public DataSet ds = new DataSet();

        public MySqlConnection conn { get; private set; } // MySqlConnection 인스턴스를 외부에서 접근할 수 있도록 함

        public ImDB()
        {
        }

        public bool DBConnection()
        {
            this.connAddr = $"Server={this.SERVER};Port={this.PORT};Database={this.DATABASE};Uid={this.DB_ID};Pwd={this.DB_PWD}" ;

            // MySqlConnection 인스턴스 생성
            conn = new MySqlConnection(this.connAddr);

            conn.Open();
            this.DB_CONN = conn.Ping();

            if (this.DB_CONN)
                Console.WriteLine("Success DB Connection");
            else
                Console.WriteLine("Fail DB Connection");

            return this.DB_CONN;
        }
        public bool DBConnection(string serv, int port, string db, string id, string pwd)
        {
            this.SERVER = serv;
            this.PORT = port;
            this.DATABASE = db;
            this.DB_ID = id;
            this.DB_PWD = pwd;

            return DBConnection();
        }

        public bool SelectData(string sel, string tb, string wh)
        {
            string sqlQuery = $"SELECT {sel} FROM {tb} WHERE {wh};";
            return SelectData(sqlQuery);
        }
        public bool SelectData(string sel, string tb)
        {
            string sqlQuery = $"SELECT {sel} FROM {tb};";
            return SelectData(sqlQuery);
        }
        public bool SelectData(string query)
        {
            if (!DBConnection())
                return false;
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(ds);
                if (ds.Tables.Count > 0)
                    return true;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("예외 - " + Convert.ToString(ex));
                conn.Close();
            }
            return false;
        }
    }
}
