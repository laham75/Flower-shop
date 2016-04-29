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

public partial class order : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        string select = "select * from [data] ";
        SqlDataAdapter cmdd = new SqlDataAdapter(select, conn);
        DataTable dt = new DataTable();
        cmdd.Fill(dt);
        GridView1.DataSource = dt;
        DataBind();

    }
    protected void Order(object sender, EventArgs e)
    {


        conn.Open();
        string insertquery = " DELETE from [data] where UserName='" + UserName.Text + "' ";
        SqlCommand com2 = new SqlCommand(insertquery, conn);

        int i = com2.ExecuteNonQuery();

        if (i >= 1)
        {

            Response.AddHeader("REFRESH", "1");

        }

        else
        {
            Response.Write("The name you entered wrong");
        }

        conn.Close();


    }
    protected void Search_Click(object sender, EventArgs e)
    {
        conn.Open();


        string select = "select count(*) from [data] where UserName='" + UserName.Text + "'";
        SqlCommand com = new SqlCommand(select, conn);
        Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
        if (count == 1)
        {
            string select1 = "select * from [data] where UserName='" + UserName.Text + "'";
            SqlDataAdapter cmdd = new SqlDataAdapter(select1, conn);
            DataTable dt = new DataTable();
            cmdd.Fill(dt);
            GridView1.DataSource = dt;
            DataBind();
        }

        else
        {
            Response.Write("The name you entered wrong");
        }

        conn.Close();
    }

    void Page_PreInit(Object sender, EventArgs e)
    {

        String CurrentName = null;
        if (Session["New1"] != null)
        {
            CurrentName = Convert.ToString(Session["New1"].ToString().Replace(" ", ""));

            if (CurrentName == "User")
            {
                Page.MasterPageFile = "MasterPage.master";
            }

            else
            {
                if (Session["New"].ToString().Replace(" ", "") == "admin")
                    Page.MasterPageFile = "MasterE.master";
                else
                    Page.MasterPageFile = "employee.master";
            }
        }


    }

}