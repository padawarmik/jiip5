using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Commons
{
    class DbController
    {
        SqlConnection con;
        public DbController()
        {
            OpenConnection();
        }

        public int ExecStatement(string sql)
        {
            int rowsAffected = 0;
            try
            {

                SqlCommand sqlCommand = PrepareSqlCommand(sql);
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Log.Info(e.Message);
                Log.Info(sql);
            }
            return rowsAffected;
        }

        private SqlCommand PrepareSqlCommand(string sql)
        {
            SqlCommand sqlCommand = con.CreateCommand();
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;
            sqlCommand.Prepare();
            return sqlCommand;
        }

        public DataTable ExecSelect(string sql)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = null;
            try
            {
                SqlCommand sqlCommand = PrepareSqlCommand(sql);
                using (sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return dataTable;
        }

        private void OpenConnection()
        {
            this.con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
