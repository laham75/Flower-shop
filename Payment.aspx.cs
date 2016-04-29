using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//provide all the classes of the sql
using System.Configuration;


public partial class Payment : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
    static SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["New"] == null)
        {
            Response.Redirect("Login.aspx");
        }


      
    }


    protected void Pay(object sender, EventArgs e)
    {
        string t = "";

        t = ((string)Session["Type"]);

        if (Session["New"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        else
        {

            conn.Open();
            string Searchquery = " select * from [User] where Username='" + Session["New"].ToString() + "'";
            SqlCommand com2 = new SqlCommand(Searchquery, conn);
            dr = com2.ExecuteReader();
            dr.Read();
            String name = dr[0].ToString().Replace(" ", "");
            String mail = dr[1].ToString().Replace(" ", "");
            String contry = dr[2].ToString().Replace(" ", "");
            String city = dr[3].ToString().Replace(" ", "");
            String phone = dr[4].ToString().Replace(" ", "");

            dr.Close();
            string insertquery = " insert into [data] (UserName,Email,Country,City,PhoneNumber,FName,processNumber,DCompany) values (@un,@em,@co,@ci,@ph,@f,@pr,@dc) ";
            SqlCommand com = new SqlCommand(insertquery, conn);
            com.Parameters.AddWithValue("@un", name);
            com.Parameters.AddWithValue("@em", mail);
            com.Parameters.AddWithValue("@co", contry);
            com.Parameters.AddWithValue("@ci", city);
            com.Parameters.AddWithValue("@ph", phone);
            com.Parameters.AddWithValue("@f", t);
            com.Parameters.AddWithValue("@pr", TextBox1.Text);
            com.Parameters.AddWithValue("@dc", Rdlist.SelectedValue);
            com.ExecuteNonQuery();

            
            conn.Close();

            Response.Redirect("Default.aspx");


        }

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


