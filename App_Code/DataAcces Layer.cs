using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataAcces_Layer
/// </summary>
public class DataAcces_Layer
{
    //OleDbCommand cmd;
    //OleDbConnection con;
    //OleDbDataAdapter da;
    DataSet ds;
    DataTable dt;
    //******************************
    SqlCommand cmd = new SqlCommand();
    SqlConnection con = new SqlConnection();
    SqlDataAdapter da = new SqlDataAdapter();
    SqlDataReader rd;
	

        public  void connect()
        {
            //con = new SqlConnection("Data Source=ISS-66FE7C73A79;Initial Catalog=Bernawal;Integrated Security=True");
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["booksConnection"].ToString();
        
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            
                    
        }
       
        public void Repairconnection()
        {
            
            con.Close();         


        }

    public bool ExecuteSql( string strsql)
    {
        connect();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = strsql;
        cmd.ExecuteNonQuery();
        return true;    
    }

    public bool ExecuteSql_proc(string strsql)
    {
        connect();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = strsql;
        cmd.ExecuteNonQuery();
        return true;
    }
    public DataSet ReturnData( string quary)
    {
        connect();
        da = new SqlDataAdapter(quary, con);
        ds = new DataSet();
        ds.Clear();
        da.Fill(ds);
        return ds;

    }
  
    public DataTable Selectdata(string quary1)
    {
        connect();
        da = new SqlDataAdapter(quary1, con);
        dt = new DataTable();
        dt.Clear();
        da.Fill(dt);
        return dt;
    }
  
    public SqlDataReader ReadData(string quary2)
    {
        connect();
        cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = quary2;
        rd = cmd.ExecuteReader();
        return rd;
    }
    

   
}
