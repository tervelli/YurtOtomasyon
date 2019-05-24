using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace YurtOtomasyonn
{
    public class sqlBaglanti
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-9BT30JG\SQLEXPRESS;Initial Catalog=YurtOtomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }

    }
}
