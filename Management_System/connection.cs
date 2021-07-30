using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_System
{
    class connection
    {
        static string directory = System.IO.Directory.GetCurrentDirectory().ToString();

        public static SqlConnection conString = new SqlConnection(ConfigurationManager.ConnectionStrings["newConnectionString"].ConnectionString);

    }
}
