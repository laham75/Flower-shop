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

public partial class _Default : Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
    static SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        string select = "select * from [Up] ";
        SqlDataAdapter cmdd = new SqlDataAdapter(select, conn);
        DataTable dt = new DataTable();
        cmdd.Fill(dt);
        GridView1.DataSource = dt;
        DataBind();

    }




    protected void SearchByImge(object sender, EventArgs e)
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
            string insertquery = "insert into [Up] (Umg,Hash) values (@M,@H)";
            SqlCommand cmd = new SqlCommand(insertquery, conn);
            cmd.Parameters.AddWithValue("@M", path);
            string hashvalue = GetSha1Hash(path1);
            string checkuser = "select count(*) from Up where Hash='" + hashvalue + "'";
            SqlCommand com = new SqlCommand(checkuser, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());





            if (count == 1 || count > 1)
            {
                Response.Write("The Image Found");

                string select = "select * from [Up] where Hash='" + hashvalue + "'";
                SqlDataAdapter cmdd = new SqlDataAdapter(select, conn);
                DataTable dt = new DataTable();
                cmdd.Fill(dt);
                GridView1.DataSource = dt;
                DataBind();
            }
            else
            {


                Response.Write("Image Not Found");


            }




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
    protected void SearchByName(object sender, EventArgs e)
    {
        conn.Open();


        string select = "select count(*) from [Up] where Uname='" + UserName.Text + "'";
        SqlCommand com = new SqlCommand(select, conn);
        Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
        if (count == 1)
        {
            string select1 = "select * from [Up] where Uname='" + UserName.Text + "'";
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

    protected void Pay_Click(object sender, EventArgs e)
    {

        if (Session["New"]== null)
        {
            Response.Redirect("Reg.aspx");
        }
        else {



            conn.Open();
            string select = "select count(*) from [Up] where Uname='" + UserName.Text + "'";
            SqlCommand com = new SqlCommand(select, conn);
            Int32 count = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (count == 1)
            {

                String r=UserName.Text;
                Session["Type"] = r;
                Response.Redirect("Payment.aspx");

           
             

            }

            else
            {
                Response.Write("The name you entered wrong");
            }

            conn.Close();
        
        
        
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

