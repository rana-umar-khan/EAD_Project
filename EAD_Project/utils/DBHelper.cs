using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace AMS.DAL
{
    internal class DBHelper : IDisposable
    {
        //String _connStr = System.Configuration.ConfigurationManager.ConnectionStrings["AttendanceDBConnStr"].ConnectionString;
        //String _connStr = @"Data Source=DESKTOP-QG580N4\SQLEXPRESS;Initial Catalog=attendance;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        String _connStr = "Server=ad4a8875-b4eb-45e9-8a87-a7ab0105eb53.sqlserver.sequelizer.com;Database=dbad4a8875b4eb45e98a87a7ab0105eb53;User ID=pfplubjqeinhrapl;Password=KSbit55oqVSajKV53B4MaudndK7mPn7K7rMwtXCfvnPwsuGPpkdf2wvqNVfQ6RFd";
        SqlConnection _con;

        public DBHelper()
        {
            try
            {
                _con = new SqlConnection(_connStr);
                _con.Open();
            }
            catch (Exception ex) { }
        }

        public int ExecuteQuery(String sqlQuery)
        {
            int n = 0;
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                n = command.ExecuteNonQuery();
                return n;
            }
            catch (Exception ex)
            {
                return n;
            }
        }

        public Object ExecuteScalar(String sqlQuery)
        {
            Object obj = null;
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                obj = command.ExecuteScalar();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }

        public SqlDataReader ExecuteReader(String sqlQuery)
        {
            SqlDataReader obj = null;
            try
            {
                SqlCommand command = new SqlCommand(sqlQuery, _con);
                obj = command.ExecuteReader();
                return obj;
            }
            catch (Exception ex)
            {
                return obj;
            }
        }

        public void Dispose()
        {
            if (_con != null && _con.State == System.Data.ConnectionState.Open)
                _con.Close();
        }
    }
}
