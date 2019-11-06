using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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

        public void appendLog(CONVERSION_LOG statisticsObject)
        {
            string sql = String.Format("INSERT INTO [Z502_17].[CONVERSION_LOG]([CL_UnitFrom],[CL_ValueFrom]," +
                "[CL_UnitTo],[CL_ValueTo], [CL_UnitType]) VALUES('{0}',{1},'{2}',{3}, '{4}')", statisticsObject.CL_UnitFrom, statisticsObject.CL_ValueFrom,
                    statisticsObject.CL_UnitTo, statisticsObject.CL_ValueTo, statisticsObject.CL_UnitType);
            this.ExecStatement(sql);
        }
        private void OpenConnection()
        {
            this.con = new SqlConnection(ConfigurationManager.ConnectionStrings["Model1"].ConnectionString);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
