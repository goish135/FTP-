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


public partial class checkthreeday : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["yousingConnectionString"].ConnectionString);//設定連線 
    string y_1,y_2,y_3;
    DateTime today;
    string str0;
    string strr;
    string time;
    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();//連線開啟

        today = DateTime.Now; 
        DateTime a1= today.AddDays(-1);//前1天
        DateTime a2= today.AddDays(-2);//前2天
        DateTime a3 = today.AddDays(-3);//前3天
        str0 = today.ToShortDateString().ToString();//yyyy/mm/dd
        strr = today.ToString();
        string str1 = a1.ToShortDateString().ToString();
        string str2 = a2.ToShortDateString().ToString();
        string str3 = a3.ToShortDateString().ToString();
        Label1.Text = ("今天日期:" + str0 + "<br>");
        Label2.Text = ("昨天日期:" + str1 + "<br>");
        Label3.Text = ("前天日期:" + str2 + "<br>");
        Label4.Text = ("大前天日期:"+str3 + "<br>");
        time=today.ToString("H:mm:ss");//What time?
        //str0:yyyy/mm/dd
        //Response.Write(time);
        /*y_1 = a1.ToString("yyyyMMdd");
        y_2 = a2.ToString("yyyyMMdd");
        y_3 = a3.ToString("yyyyMMdd");*/

        //如果是星期天 往前減一天
        if (a1.DayOfWeek == DayOfWeek.Sunday) {  a1 = a1.AddDays(-1);  a2 = a2.AddDays(-1);  a3 = a3.AddDays(-1); }
        if (a2.DayOfWeek == DayOfWeek.Sunday) {   a2 = a2.AddDays(-1);  a3 = a3.AddDays(-1); }
        if (a3.DayOfWeek == DayOfWeek.Sunday ) {  a3 = a3.AddDays(-1);  }

        y_1 = a1.ToString("yyyyMMdd");
        y_2 = a2.ToString("yyyyMMdd");
        y_3 = a3.ToString("yyyyMMdd");

        //Response.Write(y_1+"<br>");
        //Response.Write(y_2+"<br>");
        //Response.Write(y_3+"<br>");
    }

    protected void go(object sender, EventArgs e)
    {
        //Label1.Text = ""; //放資料區
        //List<string> ListResult = new List<string>();
        //ListResult = getFTPList();
        getFTPList();
        //int count = 0;
        //foreach (var LR in ListResult)
        //{
            //count += 1;

            //Label1.Text += ("項目 " + count + ": " + LR + "<br>");

        //}
    }
    public void getFTPList()
    {
        //取得目錄(診所)名
        FtpWebRequest F = (FtpWebRequest)WebRequest.Create(new Uri("ftp連線網址"));
        F.Method = WebRequestMethods.Ftp.ListDirectory;
        F.UseBinary = true;
        F.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
        F.Credentials = new NetworkCredential("帳號", "密碼");
        StreamReader SR = new StreamReader(F.GetResponse().GetResponseStream(), System.Text.Encoding.Default);
        string d = SR.ReadLine();

        int range = 0;
        string result="";
        //====================================================================================================//
        while (d != null && range<10)
        {
            if (d.Substring(0,1) == "Y" || d.Substring(0,1) == "y")
            {
                //Response.Write(d + "<br>");
                int len = d.Length;
                string cno = d.Substring(0, 7);
                string cna = d.Substring(7, len - 7);
                //Response.Write(d.Substring(0, 7));
                //Response.Write("診所名:" + d.Substring(7, len - 7) + "<br>");

                range++;
                FtpWebRequest f = (FtpWebRequest)WebRequest.Create(new Uri("ftp://www.yousing.com.tw/" + d));
                f.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                f.UseBinary = true;
                f.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
                f.Credentials = new NetworkCredential("interm", "intermftp");
                StreamReader sr = new StreamReader(f.GetResponse().GetResponseStream(), System.Text.Encoding.Default);

                int file_1 = 0;//y存不存在
                int file_2 = 0;//yy存不存在
                int file_3 = 0;//yyy存不存在
                int s_1 = 0;
                int s_2 = 0;
                int s_3 = 0;
                bool exist = false;//exist:判斷是否為空目錄

                string str = sr.ReadLine();//讀該目錄的檔案
                char[] dechar = { ' ' };//切割字元(空白)
                while (str != null)
                {
                    exist = true;

                    string[] words = str.Split(dechar);//以空白做切割
                    int count = 0;//算第幾個字
                    int size = 0;
                    foreach (string s in words)//scan 該檔案細目
                    {
                        if (s != "")
                        {
                            count++;
                            //Response.Write(count+"<br>");--test
                            if (count == 5) size = Convert.ToInt32(s);
                            if (count == 9 && y_1 == s.Substring(0, 8)) {  file_1 = 1; s_1 = size; }
                            if (count == 9 && y_2 == s.Substring(0, 8)) {  file_2 = 1; s_2 = size; }
                            if (count == 9 && y_3 == s.Substring(0, 8)) {  file_3 = 1; s_3 = size; }

                        }
                    }
                    //Response.Write("===============<br>");--test
                    str = sr.ReadLine();
                }
                if (exist == true)
                {
                    if (file_1 == 1 && file_2 == 1 && file_3 == 1)
                    {
                        if (s_1 >= s_2 && s_2 >= s_3) {  result = "OK:資料呈遞增"; }
                        else
                        {

                            if (s_1 <= s_2)
                            {
                                int mark = 0;
                                if (s_2 - s_1 < 500000) { mark = 1; }
                                else {  mark = 2; }
                                if (mark == 1) result += ("OK:資料量更動在合理範圍內");
                                if (mark == 2) result += ("錯誤:資料量變化異常");
                            }

                            if (s_2 <= s_3)
                            {
                                int tag = 0;
                                if (s_3 - s_2 < 500000) {  tag = 1; }
                                else {  tag = 2; }
                                if (tag == 1) result += ("OK:資料量更動在合理範圍內");
                                if (tag == 2) result += ("錯誤:資料量變化異常");
                            }

                        }

                    }
                    else
                    {
                        string temp = "";
                        if (file_1 == 0) {  temp += (y_1+"/");}
                        if (file_2 == 0) {  temp += (y_2+"/");}
                        if (file_3 == 0) {  temp += (y_3+"/");}
                        result = (temp +"not found");
                    }
                    sr.Close();
                    sr.Dispose();
                    f = null;
                }
                else
                {
                    //Label7.Text = (d + "為空目錄<br>");
                    result = d+"為空目錄";
                }

                record(cno, cna, result, str0);//紀錄到資料庫
            }
            result = "";
            d = SR.ReadLine();//讀下一個目錄
            
        }
    }
    public void record(string cno, string cna, string result, string today)
    {

        //Response.Write("$" + cno + " "+cna+" "+result+" "+today+"$+<br>");
        SqlCommand cmd = new SqlCommand("INSERT INTO check2 (cn,cna,result,ctime,hms) VALUES('" + cno + "','" + cna + "','" + result + "','" + today + "','" +time+ "')", con);
        cmd.ExecuteNonQuery();
    }
    protected void show(object sender, EventArgs e)
    {
        SqlCommand command = new SqlCommand("Select * From check2 Where ctime=@no", con);
        command.Parameters.Add("@no", str0);
        SqlDataReader dr = command.ExecuteReader();
        if (dr.HasRows)
        {
            GridView1.DataSource = dr;
            GridView1.DataBind();
            GridView1.Visible = true;
            Label8.Visible = false;
        }
        else
        {
            Label8.Text = "今日還未檢查~~<br>";
            Label8.Visible = true;
        }
        //GridView1.Visible = true;
    }
    protected void close(object sender, EventArgs e)
    {
        GridView1.Visible = false;
    }
}