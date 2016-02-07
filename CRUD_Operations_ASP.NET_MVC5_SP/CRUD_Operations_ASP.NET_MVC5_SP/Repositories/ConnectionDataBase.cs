using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Operations.Repositories
{
    public class ConnectionDataBase
    {
        private static string ConnectionString;

        protected SqlConnection ConnectionSQL;
        protected SqlCommand CmdSQL;
        protected SqlDataReader ReaderSQL;
        protected SqlDataAdapter AdapterSQL;
        protected DataTable TablesSQL;

        public static string ConnectionDB
        {
            get
            {
                if (ConnectionString == null || ConnectionString == string.Empty)
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString;
                }

            return ConnectionString;
            }
        }
    }
}