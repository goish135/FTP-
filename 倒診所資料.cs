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

public partial class insert3: System.Web.UI.Page
{


    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
    }
    protected void i3(object sender, EventArgs e)
    {


        List<string> ListResult = new List<string>();
        ListResult = getFTPList();

        foreach (var LR in ListResult)
        {
            int len = LR.Length;
            string cn = LR.Substring(0, 7);
            string cname = LR.Substring(7, len - 7);
            string all=LR;
            SqlCommand cmd = new SqlCommand("INSERT INTO list3 (customer) VALUES('" + all + "')", con);
            cmd.ExecuteNonQuery();
        }

    }
    public List<string> getFTPList()
    {
        List<string> strList = new List<string>();

        FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://"));
        f.Method = WebRequestMethods.Ftp.ListDirectory;
        f.UseBinary = true;
        f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f.Credentials = new NetworkCredential("", "");
        StreamReader sr = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);

        string str = sr.ReadLine();
        while (str != null)
        {
            string tmp = str.Substring(0, 1);
            if (tmp == "Y" || tmp == "y")//為了只取得診所
            {

                strList.Add(str);
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