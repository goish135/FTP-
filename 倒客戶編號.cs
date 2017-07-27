using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;//連ftp
using System.IO;//for reader

public partial class insert : System.Web.UI.Page
{

    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
        con.Open();
        conn.Open();
    }

    /*protected void btn_click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO 白名單 客戶代號 VALUES('tbx.Text')",con);
        cmd.ExecuteNonQuery();
        Label1.Visible = true;
        Label1.Text = "Your DATA stored Successfully!";
        TextBox1.Text = "";
    }*/

    protected void btn_click(object sender, CommandEventArgs e)//手動key資料
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
        con.Open();
        string ss = TextBox1.Text;
        //Response.Write(ss);
        SqlCommand cmd = new SqlCommand("INSERT INTO 白名單 (客戶代碼) VALUES('"+TextBox1.Text+"')", con);
        cmd.ExecuteNonQuery();
        Label1.Visible = true;
        Label1.Text = "Your DATA stored Successfully!";
        TextBox1.Text = "";
        GridView1.Visible = true;
    }
    protected void insert_2(object sender, EventArgs e)
    {
        /*FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://"));
        f.Method = WebRequestMethods.Ftp.ListDirectory;//取得目錄名稱
        f.UseBinary = true;
        f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f.Credentials = new NetworkCredential("", "");
        StreamReader read = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
        List<string> myList = new List<string>();
        string clinic = read.ReadLine();
        while(clinic!=null)
        {
            myList.Add(clinic);
            read.ReadLine();
        }
        read.Close();
        read.Dispose();
        f = null;
        
        /*foreach (string str in myList)
        {
            Label2.Text += (str+"<br>");
        }*/
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
        //conn.Open();
        //SqlCommand cd = new SqlCommand("INSERT INTO 白名單 客戶代號 VALUES(@lr)", conn);
        Label1.Text = ""; //放資料區
        List<string> ListResult = new List<string>();
        ListResult = getFTPList();
        //int count = 0;
        foreach (var LR in ListResult)
        {
          
            
            Label2.Text = LR;
            SqlCommand cmd = new SqlCommand("INSERT INTO list (cno) VALUES('" + Label2.Text + "')", conn);
            cmd.ExecuteNonQuery();
            
            //count += 1;
            //Label2.Text += ("項目 " + count + ": " + LR + "<br>");
            //Response.Write(LR+"<br>");

        }
        //GridView1.Visible = true;
    }
    public List<string> getFTPList()
    {
        List<string> strList = new List<string>();

        FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://"));
        f.Method = WebRequestMethods.Ftp.ListDirectory;
        f.UseBinary = true;
        f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f.Credentials = new NetworkCredential("", "");
        //reader = new StreamReader(listResponse.GetResponseStream(), System.Text.Encoding.Default);
        StreamReader sr = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);

        string str = sr.ReadLine();
        while (str != null)
        {
            string tmp = str.Substring(0, 1);
            if (tmp == "Y" || tmp == "y")//為了只取得診所
            {
                string tp = str.Substring(0, 7);
                strList.Add(tp);
            }
            str = sr.ReadLine();
        }
        sr.Close();
        sr.Dispose();
        f = null;
        return strList;
    }

    protected void view(object sender, EventArgs e)
    {
        GridView1.Visible = true;
    }
}