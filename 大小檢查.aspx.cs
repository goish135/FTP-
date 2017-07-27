using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


public partial class sizebechecked : System.Web.UI.Page
{
    //Response.Write(DateTime.Now.ToShortTimeString());

    public static string DD = DateTime.Now.ToShortTimeString();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
    SqlConnection conn= new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);
    //con.Open();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();
        conn.Open();
        Label4.Text = "";
        Label4.Text=(DD);    
    }
    List<string> list = new List<string>();//將結果存放進資料表中
    List<int> number = new List<int>();//store error number
    List<string> file = new List<string>();//filename
    string filePath = "D:/records/size.txt";

    //write
    public void StreamWriteTextFile(string strContent)
    {
        StreamWriter objStreamWriter = new StreamWriter(filePath,true);
        objStreamWriter.WriteLine(strContent);
        objStreamWriter.Close();
        objStreamWriter.Dispose();
    }

    
    //{

    //}
   
    public void checkAll(object sender, EventArgs e)
    {
      
        Label4.Text ="";
        DD = DateTime.Now.ToShortTimeString();
        Label4.Text = DD;
        FtpWebRequest f2 = (FtpWebRequest)WebRequest.Create(new Uri("ftp://連線網址"));
        f2.Method = WebRequestMethods.Ftp.ListDirectory;
        f2.UseBinary = true;
        f2.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        f2.Credentials = new NetworkCredential("帳號", "密碼");
        StreamReader sr2 = new StreamReader(f2.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
        string d= sr2.ReadLine();
        
        //Response.Write(d + "<br>");
        int cc = 0;
        int r = 0;
        int check= 0;//0:該診所檢查結果 OK //1:該診所 No OK 
        while (d!= null&&cc<=50)
        {
            check = 0;
            FtpWebRequest f22 = (FtpWebRequest)WebRequest.Create(new Uri("ftp://link" + d));
            f22.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            f22.UseBinary = true;
            f22.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
            f22.Credentials = new NetworkCredential("帳號", "密碼");
            StreamReader sr22 = new StreamReader(f22.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
            char[] dechar = { ' ' };

            string str = sr22.ReadLine();
            int nok = 0;//計算(檔案大小異常)統計
            while (str != null)
            {
                
                string[] words = str.Split(dechar);
                int count = 1;
                int c = 0;
                int flag = 0;
                int mark= 0;
                foreach (string s in words)
                {

                    if (s != "")
                    {
                        if (c == 4 && flag == 0)
                        {
                          
                            //Label1.Visible = true;
                            long size = Convert.ToInt32(s);
                            if (size < 1000000)
                            {
                                //Label1.Text += ("file size too small:" + size + "=>");
                                mark = 1;
                                check = 1;
                                nok++;
                            }
                            c = 0;
                            flag = 1;
                        }
                        if (c == 4 && flag == 1 && mark == 1)
                        {
                            //Label1.Text += (d + "filename:" + s + "<br/>");
                            //StreamWriteTextFile(d+" "+s);
                            list.Add(d);
                            file.Add(s);
                            //Response.Write(r+list[r]+"<br/>");
                            //Response.Write("XD"+list.Count+"XD");

                            //ListBox1.Items.Add(list[r]);
                            r++;
                        }
                    
                        c++;
                    }
                    count++;
                }
                str = sr22.ReadLine();
            }//str end //檢查該目錄的每個檔案
            if (check == 1)//該目錄error occur
            {
                DateTime myDate = DateTime.Now;
                string myDateString = myDate.ToString("yyyyMMdd HH:mm:ss");
                Response.Write(myDateString);
                SqlCommand cmd2 = new SqlCommand("INSERT INTO sum (cno,Error,cday) VALUES('" + d + "','" + nok + "','" + myDateString + "')", conn);

                cmd2.ExecuteNonQuery();
            }
            sr22.Close();
            sr22.Dispose();
            f22 = null;
            
            d = sr2.ReadLine();
        
            cc++;
        }
        Button2.Visible = false;
       
       
     
            for (int i = 0; i < list.Count; i++)
            {
                string nn = list[i].Substring(0, 7); 
                 
                SqlCommand cmd = new SqlCommand("INSERT INTO check1 (cno,fn,errornumber) VALUES('" +nn+ "','" +file[i]+ "','3:檔案過小')", con);
                cmd.ExecuteNonQuery();
                //ListBox1.Items.Add(list[i]);
            }
    
    }
    public void record(object sender, EventArgs e)
    {
        GridView1.Visible = true;
    }
    protected void hidden(object sender, EventArgs e)
    {
        GridView1.Visible = false;
    }
}