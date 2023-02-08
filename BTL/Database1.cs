using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace BTL
{
    class Database1
    {
        private SqlConnection Cnn;
        private SqlDataAdapter da;
        private SqlCommandBuilder Cmdb;

        public static Database1 singleton = null;
        public static Database1 Singleton
        {
            get
            {
                if (singleton == null)
                {
                    singleton = new Database1();
                }
                return singleton;
            }
        }
        public Database1()
        {
            string conStr = @"Data Source=DESKTOP-C0C2AH8\SQLEXPRESS;Initial Catalog=QLLDGV;Integrated Security=True";
            this.Cnn = new SqlConnection(conStr);
        }

        public DataTable LoadData(string sql)
        {
            DataTable tb = new DataTable();
            da = new SqlDataAdapter(sql, this.Cnn);
            da.Fill(tb);
            return tb;
        }
    }
}
