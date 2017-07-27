using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Threading;
using System.IO;

public partial class checkAll : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void view_click(object sender, EventArgs e)
    {
        datarea.Text = ""; //放資料區
        List<string> ListResult = new List<string>();
        ListResult = getFTPList();
        int count = 0;
        foreach (var LR in ListResult)
        {
            count += 1;
            datarea.Text += ("項目 " + count + ": " + LR + "<br>");

        }
        Button1.Visible = false;
    }
    public List<string> getFTPList()
    {
        List<string> strList = new List<string>();
        FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://www.yousing.com.tw/"));
        f.Method = WebRequestMethods.Ftp.ListDirectory;
        f.UseBinary = true;
        f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f.Credentials = new NetworkCredential("interm", "intermftp");
        //reader = new StreamReader(listResponse.GetResponseStream(), System.Text.Encoding.Default);
        StreamReader sr = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);

        string str = sr.ReadLine();
        Response.Write(str + "*<br><br>");
        int d = 0;
        int len = 0;
        while (str != null && d <= 57)
        {

            if (len == 11)
            {
                FtpWebRequest f1 = (FtpWebRequest)WebRequest.Create(new Uri("ftp://Link" + str));
                f1.Method = WebRequestMethods.Ftp.ListDirectory;
                f1.UseBinary = true;
                f1.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
                f1.Credentials = new NetworkCredential("帳號", "密碼");
                StreamReader srr = new StreamReader(f1.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
                string s2 = srr.ReadLine();
                int mark = 0;
                if (s2 == null) { Response.Write("此目錄無任何檔案<br>"); mark = 1; }
                int ll = 0;
                if (mark == 0)
                {
                    ll = s2.Length;
                    Response.Write(ll);
                }
                if (ll == 31 && mark == 0)
                {
                    Response.Write("<br>" + s2 + "$$" + "<br>");
                    string s4 = s2.Substring(0, 11);
                    Response.Write(s4 + "@@<br>");

                    string s3 = s2.Substring(12);
                    //Response.Write(s3);
                    string yy;
                    int y;
                    bool b;
                    int[] day1;
                    int[] day2;
                    int[] day2017;
                    day1 = new int[367];//366
                    day2 = new int[366];//365
                    day2017 = new int[366];//365
                    int i;
                    int mk = 0;
                    while (s2 != null)
                    {
                        //int y;
                        if (mk == 0)
                        {
                            yy = s2.Substring(12, 4);//取得年
                            string ss = s2.Substring(21, 3);
                            string check = s2.Substring(0, 4);
                            int k, w;//數字k //數字w
                            if (check != "SBSE" && yy == "2016")
                            {
                                k = Convert.ToInt32(ss);
                                if (k < 366) day2[k] = 1;
                                //Response.Write("hi"+"<br>");
                            }
                            else if (check != "SBSE" && yy == "2017")
                            {
                                w = Convert.ToInt32(ss);
                                if (w < 366) day2017[w] = 1;

                            }
                        }

                        //Response.Write(s3+"<br>");
                        strList.Add(s3);
                        //Response.Write(s3);
                        s2 = srr.ReadLine();
                        if (s2 != null)
                        {
                            int len2 = s2.Length;
                            //mk = 1;
                            if (len2 != 31)
                            { Response.Write(s2 + "XXX" + mk + "YYY" + len2 + "<br>"); mk = 1; }
                            else mk = 0;
                        }

                        //else mk = 0;
 
                        //Response.Write("<br>"+"mk--"+mk+"<br>");
                    }

                    //datarea.Text = str;
                    Response.Write("2016檔案移失區" + "<br>");
                    Response.Write("===============" + "<br>");
                    int M, D = 0;
                    int record = 0;
                    for (int z = 1; z < 366; z++)
                    {
                        M = 1;
                        if (day2[z] != 1)
                        {
                            //Response.Write("第" + z + "天" + "不存在" + "<br>");
                            //int M = 1,D;
                            record = z;
                            for (int m = 1; m <= 12; m++)
                            {
                                int md = DateTime.DaysInMonth(2016, m);//第m月的天數
                                int temp = record - md;
                                if (temp > 0) { M = M + 1; record = record - md; }
                                else { D = record; break; }
                            }
                            if (d == 1) Response.Write("2016" + "/" + M + "/" + D + "<br>");
                        }
                    }
                    Response.Write("===============" + "<br><br>");

                    /*Response.Write("2017檔案遺失區" + "<br>");
                    Response.Write("--------------------" + "<br>");
                    int M1, D1;
                    int r;
                    for (int u = 1; u < 366; u++)
                    {
                        M1 = 1;
                        D1 = 0;
                        if (day2017[u] != 1)
                        //Response.Write("第" + u + "天" + "不存在" + "<br>");
                        {
                            r = u;
                            for (int m = 1; m <= 12; m++)
                            {
                                int md = DateTime.DaysInMonth(2017, m);//第m月的天數
                                int temp = r - md;
                                if (temp > 0) { M1 = M1 + 1; r = r - md; }
                                else { D1 = r; break; }
                            }
                            Response.Write("2017" + "/" + M1 + "/" + D1 + "<br>");
                        }
                    }
                    Response.Write("---------------------" + "<br>");
                    */
                }
            }
            str = sr.ReadLine();
            len = str.Length;

            Response.Write(str + " " + len + "*<br>");
            d++;
        }

        sr.Close();
        sr.Dispose();
        f = null;
        return strList;
    }
}