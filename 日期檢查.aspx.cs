using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Threading;
using System.IO;

public partial class set : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /*protected void image_click(object sender, ImageClickEventArgs e)
    {
        Calendar2.Visible = true;
    }*/
    protected void CHANGE(object sender, EventArgs e)
    {

        TextBox2.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        
    }

    protected void click(object sender, EventArgs e)
    {
        //lboxsource.Items.Add(TextBox2.Text);--test
        FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://連線網址"+TextBox3.Text));
        f.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        f.UseBinary = true;
        f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f.Credentials = new NetworkCredential("帳號", "密碼");
        StreamReader sr = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);

        char[] dechar = { ' ' };
        string str = sr.ReadLine();//scan該目錄下的檔案
        int exist = 0;//0:該檔不存在
        int f2=0;
        while (str != null)
        {
            //strList.Add(str);
            string[] words = str.Split(dechar);
            int count = 1;
            int c = 0;
            int flag = 0;
            f2 = 0;
            foreach (string s in words)//scan 該檔案細目
            {

                if (s != "")
                {
                    int v = 0;//版本號:version
                    if (c == 4 && flag == 0)
                    {
                        //Response.Write(count + ":$" + s + "*" + "<br>");
                        long size = Convert.ToInt32(s);
                        if (size < 1000000)
                        {
                            //Response.Write("file size too small:" + size + "=>");
                            f2 = 1;
                        }
                        c = 0;
                        flag = 1;
                    }
                    if (c == 4 && flag == 1)
                    {
                        //Response.Write("filename:" + s + "<br>");//c重新計算到4會到檔名 flag = 1:順序是第二個 f2:檔案過小檔

                        int len = s.Length;
                        int startindex = len - 7;
                        int beginindex = len - 3;
                        string fn1 = s.Substring(startindex, 7);
                        string fn2 = s.Substring(beginindex, 3);
                        string jud1 = ".sql.7z";
                        string jud2 = ".7z";
                        if (jud2 == fn2)
                        {
                            if (jud1 == fn1) { v = 1; }
                            else {  v = 2; }
                        }
                        else {  v = 3; }
                    }
                        string dd = TextBox2.Text;
                        string newdd = dd.Substring(0, 4) + dd.Substring(5, 2) + dd.Substring(8, 2); 
                        //if (dd == s) exist = 1;
                        //比對日期
                        if (v==1)
                        {
                            string s1 = s.Substring(0, 8);
                            //Response.Write("v1"+s1+"<br>");
                            //Response.Write("newdd:" + newdd + "<br>");
                            if (newdd == s1)
                            {
                                exist = 1; 
                                break;
                            }
                        }
                        else if (v==2)
                        {
                            string s2 = s.Substring(0, 7);//case1 單月 或 單日
                            string s22 = s.Substring(0, 6);//case2 單月又單日
                           
                            string sd = s2.Substring(4, 2);//case1:單日
                            int sdd = Convert.ToInt32(sd);
                            string year = s.Substring(0,4);
                            string month = s.Substring(4, 2);
                            string date = s.Substring(6, 2);

                            string y2   = newdd.Substring(0,4);
                            if (year == y2)//case1+case2
                            {
                                if (sdd > 12)//代表是單月//ex:2017518
                                {
                                    int a = Convert.ToInt32(month);        
                                    string sm = s2.Substring(4, 1);
                                    int b = Convert.ToInt32(sm);
                                    if (a == b)
                                    {
                                        string ddd = s2.Substring(5, 2);
                                        int cc=Convert.ToInt32(ddd);
                                        int d = Convert.ToInt32(date);
                                        if (cc == d) exist = 1; 
                                    }
                                }
                                else//單日 //2017121//201711
                                {
                                    int m3 = Convert.ToInt32(month);
                                    if (sdd == m3)//月份相同
                                    {
                                        string z=s2.Substring(6, 1);
                                        int zi = Convert.ToInt32(z);
                                        int x = Convert.ToInt32(date);
                                        if (zi == x) exist = 1;
                                    }
                                }
                            }
                        }
                        else if (v == 3)
                        {
                            //不用比對 bec 不用檢查
                            exist = 0;
                        }
                    //}
                    c++;
                    count++;
                }
                
            }
            if (exist == 1) break;
            str = sr.ReadLine();
        }//while scan
       
        if (exist == 1&&f2==0) lboxsource.Items.Add(TextBox2.Text + "該天檔案存在&&檔案大小正常");
        else if (exist == 1 && f2 == 1) lboxsource.Items.Add(TextBox2.Text + "該天檔案存在But檔案大小不正常:過小");
        else lboxsource.Items.Add(TextBox2.Text + "該天檔不存在<br>");
        
    }

}