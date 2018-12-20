using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

public class connect
{
    public SqlConnection con;
    public SqlCommand cmd;
    public SqlDataReader dr;

    public connect()
    {
        con = new SqlConnection("Data Source=ESKTOP-9SJ7AL5,Initial Catalog=Reminder,Integrated Security=SSPI");
        cmd = new SqlCommand();
    }
    public void start()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
            con.Open();
            cmd.Connection = con;
        }
        else
        {
            con.Open();
            cmd.Connection = con;
        }
    }
    public void dml(String sql)
    {
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();
    }
    public DataSet fill(String sql)
    {
        SqlDataAdapter da = new SqlDataAdapter(sql, con);
        DataSet ds = new DataSet();
        da.Fill(ds, "tab");
        return ds;
    }
    public SqlDataReader read(String sql)
    {
        cmd.CommandText = sql;
        return cmd.ExecuteReader();
    }
}
