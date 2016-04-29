using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//provide all the classes of the sql
using System.Configuration;
using System.Data;
using System.IO;
using System.Security.Cryptography;

public partial class order_user : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
        conn.Open();
        string select = "select * from [data] where UserName='" + Session["New"].ToString() + "'";
        SqlDataAdapter cmdd = new SqlDataAdapter(select, conn);
        DataTable dt = new DataTable();
        cmdd.Fill(dt);
        
        GridView1.DataSource = dt;
        DataBind();
        conn.Close();

    }
   

    

}