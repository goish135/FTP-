using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


public partial class history : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
    }
    protected void go(object sender, EventArgs e)
    {
        if (TextBox2.Text == "")
        {
            Label1.Text = "攔位未填妥~~<br>";
            Label1.Visible = true;
            GridView1.Visible = false;
        }
        else
        {
            SqlCommand command = new SqlCommand("Select [cn] as 診所編號, [cna] as 診所名稱 ,[result] as 檢查結果, [ctime] as 檢查日期,[hms] as 檢查時間  From check2 Where (cna Like '%'+@name+'%')", con);
            //command.Parameters.Add("@no", TextBox1.Text);
            command.Parameters.Add("@name", TextBox2.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                GridView1.DataSource = dr;
                GridView1.DataBind();
                GridView1.Visible = true;
                Label1.Visible = false;
                //TextBox1.Text = "";
                TextBox2.Text = "";
            }
            else
            {
                Label1.Text = "查無資料~~<br>";
                Label1.Visible = true;
                GridView1.Visible = false;
                //TextBox1.Text = "";
                TextBox2.Text = "";
            }
        }
    }
}