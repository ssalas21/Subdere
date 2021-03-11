using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class Connection {

        public void Coneccion(string query) {
            string strConn = "Data Source=192.168.1.25;Database=Permisos_de_Circulacion;User Id=sa;Password=PCHNCV:2006-10;";
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();
            try {
                // Settings.  
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 12 * 3600; //// Setting timeeout for longer queries to 12 hours.  
                // Open.  
                sqlConnection.Open();
                // Result.  
                sqlCommand.ExecuteNonQuery();
                // Close.  
                sqlConnection.Close();
            } catch (Exception ex) {
                // Close.  
                sqlConnection.Close();
                throw ex;
            }
        }
    }
}
