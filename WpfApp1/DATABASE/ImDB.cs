using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApp1.DATABASE
{
    public class ImDB
    {
        string _server = "localhost";       //DB 서버 주소
        int _port = 3306;                   //DB 서버 포트
        string _database = "world";         //DB 이름(스키마)
        string _id = "clts";                //계정 아이디
        string _pw = "clts";                //계정 비밀번호

        string _connectionsAddress = "";

        public MySqlConnection conn { get; private set; } // MySqlConnection 인스턴스를 외부에서 접근할 수 있도록 함

        public ImDB()
        {
            _connectionsAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", _server, _port, _database, _id, _pw);

            // MySqlConnection 인스턴스 생성
            conn = new MySqlConnection(_connectionsAddress);

            try
            {
                // 데이터베이스 연결
                conn.Open();
                Console.WriteLine("연결 성공!");

                SelectData("Name", "city");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("연결 실패: " + ex.Message);
            }
        }

        public void SelectData(string sel, string tb, string wh)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = string.Format("SELECT {0} FROM {1} WHERE {2};", sel, tb, wh);
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                adapter.Fill(ds, "members");
                if (ds.Tables.Count > 0)
                {
                    foreach(DataRow dr in ds.Tables[0].Rows)
                    {
                        Console.WriteLine(dr["name"]);
                    }
                }
            }
            catch
            {

            }
        }
        public void SelectData(string sel, string tb)
        {
            try
            {
                DataSet ds = new DataSet();
                string sql = string.Format("SELECT {0} FROM {1};", sel, tb);
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
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
    }
}
