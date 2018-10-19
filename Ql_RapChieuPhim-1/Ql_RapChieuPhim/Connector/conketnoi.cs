using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
//cơ chế làm việc của các lớp UI-->Bus-->Connect-->Database
namespace Connector
{
    public class congketnoi // cổng kết nối 
    {
        
        public  QL_RAPCHIEUPHIMEntities connect = new QL_RAPCHIEUPHIMEntities(); 
        public SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-A9I9PAN\SQLEXPRESS; initial catalog = QL_RAPCHIEUPHIM; integrated security = True");
        public DataTable laydulieu(string a)
        {  
            cnn.Open();
            string sql ="select * from "+a;
            SqlCommand com = new SqlCommand(sql, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable truyvan(string a)
        {
            cnn.Open();
            SqlCommand com = new SqlCommand(a, cnn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public string layid(string a)
        {
            cnn.Close();
            cnn.Open();
            string sql = "EXEC "+a;
            SqlCommand com = new SqlCommand(sql, cnn);
            return (string)com.ExecuteScalar();
        }
        

    }
}
        
         
