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
public partial class Management : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        string select = "select * from [Up] ";
        SqlDataAdapter cmdd = new SqlDataAdapter(select, conn);
        DataTable dt = new DataTable();
        cmdd.Fill(dt);
        GridView1.DataSource = dt;
        DataBind();

    }




    protected void AddFlower(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {

            String st = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath(".") + "\\Up\\" + st);

            String path1 = Server.MapPath("~//Up//" + st.ToString());
            String path = "~//Up//" + st.ToString();


            //FileInfo f = new FileInfo(path);
            //string fullname = f.FullName;
            conn.Open();
            string insertquery = "insert into [Up] (Uname,Umg,Price,Hash) values (@U,@M,@P,@H)";
            SqlCommand cmd = new SqlCommand(insertquery, conn);
            cmd.Parameters.AddWithValue("@U", Name.Text);
            cmd.Parameters.AddWithValue("@M", path);
            Int32 pri = Convert.ToInt32(DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@P", pri);
            string hashvalue = GetSha1Hash(path1);
            string checkuser = "select count(*) from Up where Hash='" + hashvalue + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());





            if (count == 1 || count > 1)
            {
                Response.Write("The Image Already has Uploaded");


            }
            else
            {


                cmd.Parameters.AddWithValue("@H", hashvalue);
                cmd.ExecuteNonQuery();
                Label3.Text = " Image Uploaded Successfully";
                Response.Write("Image Uploaded Successfully");


            }


            string select = "select * from [Up] ";
            SqlDataAdapter cmdd = new SqlDataAdapter(select, conn);
            DataTable dt = new DataTable();
            cmdd.Fill(dt);
            GridView1.DataSource = dt;
            DataBind();

            conn.Close();
        }
        else
        {
            Label3.Text = "Plz Upload your photo ";
        }

    }
    public string GetSha1Hash(string filePath)
    {
        using (FileStream fs = File.OpenRead(filePath))
        {
            SHA1 sha = new SHA1Managed();
            return BitConverter.ToString(sha.ComputeHash(fs));
        }
    }

    protected void RemoveFlower(object sender, EventArgs e)
    {
        conn.Open();
        string insertquery = " DELETE from [Up] where Uname='" + Name.Text + "' ";
        SqlCommand com2 = new SqlCommand(insertquery, conn);

        int i = com2.ExecuteNonQuery();

        if (i == 1)
        {

            Response.AddHeader("REFRESH", "1");

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