using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace CompleteWebAPIApp.Models
{
    public class ContextDB
    {
        public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConn"].ConnectionString);

        public List<EmpModelClass> Get()
        {
            List<EmpModelClass> list = new List<EmpModelClass>();
            SqlCommand cmd = new SqlCommand("select * from emp",conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dataRow in dt.Rows)
            {
                list.Add(new EmpModelClass {
                    ID = Convert.ToString(dataRow[0]),
                    //ID = Convert.ToInt32(dataRow[0]),
                    NAME = Convert.ToString(dataRow[1]),
                    AGE = Convert.ToString(dataRow[2])
                    // AGE = Convert.ToInt32(dataRow[2])
                });
            }
            return list;
        }

        public bool Add(EmpModelClass obj)
        {
            string query = "insert into emp values('" + obj.NAME + "','" + obj.AGE + "')";
            SqlCommand cmd = new SqlCommand(query,conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Edit(string id, EmpModelClass obj)
        {
            string query = "update [dbo].[emp] set name = '"+obj.NAME+"',age = '"+obj.AGE+"' where id = '"+obj.ID+"'";
            SqlCommand cmd = new SqlCommand(query,conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        public bool Delete(int id)
        {
            string query = "delete  emp where id = '"+id+"'";
            SqlCommand cmd = new SqlCommand(query,conn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            int i = cmd.ExecuteNonQuery();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}