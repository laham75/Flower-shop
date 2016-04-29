using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;//provide all the classes of the sql
using System.Configuration;

public partial class Employees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


   
    protected void RemoverUser(object sender, EventArgs e)
    {
        String type = D.SelectedValue;

        if (type == "Customer")
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [User] where Username='" + U.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
            

            if (count == 1)
            {
              
                string del = "DELETE from [User] where Username='" + U.Text + "' ";
                SqlCommand comm = new SqlCommand(del, conn);
                comm.ExecuteNonQuery();
                Response.Write("Dleteed Successfully");
            }

            else
            {
                Response.Write("please inter the correct name");
            }

            


    
             
        }

        else
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [employee] where Username='" + U.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());


            if (count == 1)
            {

                string del = "DELETE from [employee] where Username='" + U.Text + "' ";
                SqlCommand comm = new SqlCommand(del, conn);
                comm.ExecuteNonQuery();
                Response.Write("Dleteed Successfully");
            }

            else
            {
                Response.Write("please inter the correct name");
            }

        }
    }


    protected void AddUser(object sender, EventArgs e)
    {
        String type = D.SelectedValue;

        if (type == "Customer")
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [User] where Username='" + U.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (count == 1)
            {

                Response.Write("user already exists");
            }

            else
            {
                string add = "insert into [User] (UserName,Password) values (@u,@p)";
                SqlCommand comm = new SqlCommand(add, conn);
                comm.Parameters.AddWithValue("@u", U.Text);
                comm.Parameters.AddWithValue("@p", P.Text);
                comm.ExecuteNonQuery();
                Response.Write("Add Successfully");
                conn.Close();
            }

           
            
        }

        else
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
            conn.Open();
            string checkuser = "select count(*) from [employee] where Username='" + U.Text + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (count == 1)
            {

                Response.Write("user already exists");
            }

            else
            {
                string add = "insert into [employee] (UserName,Password) values (@u,@p)";
                SqlCommand comm = new SqlCommand(add, conn);
                comm.Parameters.AddWithValue("@u", U.Text);
                comm.Parameters.AddWithValue("@p", P.Text);
                comm.ExecuteNonQuery();
                Response.Write("Add Successfully");
                conn.Close();
            }
        }
    }
   

    }


