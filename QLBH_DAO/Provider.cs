using System.Data;
using System.Data.SqlClient;

namespace QLBH_DAO
{
    public class Provider
    {
        static string ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=SaleExample;Integrated Security=True";
        SqlConnection Connection { get; set; }

        public void Connect()
        {
            try
            {
                if (Connection == null)
                    Connection = new SqlConnection(ConnectionString);
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            if (Connection != null && Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        public DataTable Select(CommandType type, string sql, params SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlCommand = Connection.CreateCommand();
                sqlCommand.CommandType = type;
                sqlCommand.CommandText = sql;
                if (param != null && param.Length > 0)
                    sqlCommand.Parameters.AddRange(param);
                SqlDataAdapter sqlData = new SqlDataAdapter(sqlCommand);
                DataTable table = new DataTable();
                sqlData.Fill(table);
                return table;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExeCuteNonQuery(CommandType type, string sql, params SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlCommand = Connection.CreateCommand();
                sqlCommand.CommandType = type;
                sqlCommand.CommandText = sql;
                if (param != null && param.Length > 0)
                    sqlCommand.Parameters.AddRange(param);
                int nRow = sqlCommand.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int ExeCuteScalarInt(CommandType type, string sql, params SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlCommand = Connection.CreateCommand();
                sqlCommand.CommandType = type;
                sqlCommand.CommandText = sql;
                if (param != null && param.Length > 0)
                    sqlCommand.Parameters.AddRange(param);
                int rs = int.Parse(sqlCommand.ExecuteScalar().ToString());
                return rs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string ExeCuteScalar(CommandType type, string sql, params SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlCommand = Connection.CreateCommand();
                sqlCommand.CommandType = type;
                sqlCommand.CommandText = sql;
                if (param != null && param.Length > 0)
                    sqlCommand.Parameters.AddRange(param);
                string rs = sqlCommand.ExecuteScalar().ToString();
                return rs;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
