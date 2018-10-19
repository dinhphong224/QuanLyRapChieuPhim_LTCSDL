using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model;
using Connector;
// đây là tầng trung gian lấy thông điệp từ giao diện xuốnng database
//và ngược lại nhưng nó phải thông qua tầng Model, tầng này phải gắn liền
//với tầng model 
namespace Bus
{
    public class BSSPhim
    {
        congketnoi ketnoi =null;
        public  BSSPhim()
        {
            ketnoi = new congketnoi();
        }
        public List<PHIM> laydsphim()
        {
            SqlDataReader dr = null;
            List<PHIM> ds = null;
            try
            {
                ketnoi.laydulieu("PHIM");
                ds = new List<PHIM>();
                while (dr.Read())
                {
                    PHIM phim = new PHIM();
                    phim.MAPHIM = dr.GetString(0);
                    phim.TENPHIM = dr.GetString(1);
                    phim.NAMSX = dr.GetInt32(2);
                    phim.Daodien = dr.GetString(3);
                    phim.MATL = dr.GetString(4);
                    phim.QuocGia = dr.GetString(5);
                    phim.NgayKhoiChieu = dr.GetDateTime(6);
                    ds.Add(phim);
                }
                ketnoi.dongketnoi();
        }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return ds;

        }
    }
}
