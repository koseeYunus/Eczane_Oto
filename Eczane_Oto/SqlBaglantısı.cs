using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Eczane_Oto
{
    class SqlBaglantısı
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=MYCOMPUTER;Initial Catalog=eczane_otomasyon;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
