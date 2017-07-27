using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Threading;
using System.IO;

public partial class checkfilesize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void click(object sender, EventArgs e)
    {
        //Label1.Text = "";
        string input2 = DropDownList2.Text.ToString();
        //string input = TextBox1.Text.ToString();
        //Label2.Text = "";
        //Label2.Text += (input+"<br>");
        FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://連線網址"+input2));
        f.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        f.UseBinary = true;
        f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f.Credentials = new NetworkCredential("帳號", "密碼");
        StreamReader sr = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
        char[] dechar = { ' ' };
        int exist = 0;
        Label1.Text = "";
        string str = sr.ReadLine();
        while (str != null)
        {

            string[] words = str.Split(dechar);
            int count = 1;
            int c = 0;
            int flag = 0;
            int f2 = 0;
          
            foreach (string s in words)
            {

                if (s != "")
                {
                    if (c == 4 && flag == 0)
                    {
                        //Response.Write(count + ":$" + s + "*" + "<br>");
                        Label1.Visible = true;
                        long size = Convert.ToInt32(s);
                        if (size < 1000000)
                        {
                            Label1.Text += (size + "=>");
                            f2 = 1;
                            exist = 1;
                        }
                        c = 0;
                        flag = 1;
                    }
                    if (c == 4 && flag == 1 && f2 == 1) Label1.Text += (" " + s + "<br>");
                    c++;
                }
                count++;
            }
            str = sr.ReadLine();
        }

        if (exist == 0)
        {
            Label2.Visible = true;
            Label2.Text = (DropDownList2.Text + "所有檔案大小皆超過1MB");
        }
        else { Label2.Visible = false; }

        sr.Close();
        sr.Dispose();
        f = null;
    }
}