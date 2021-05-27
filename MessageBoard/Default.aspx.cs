using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MessageBoard
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkLogin_Click(object sender, EventArgs e)
        {
            //设置Conn对象的连接字符串
            string ConnSql = ConfigurationManager.ConnectionStrings["ConnString2021"].ConnectionString;
            //声明Conn为一个SQL Server连接对象
            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();
            //使用MD5算法加密用户口令
            //string SecPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(TextPwd.Text, "MD5");
            string SecPwd = Enocder.MD5Hash(TextPwd.Text);
            string SelectSql = string.Format(" SELECT * FROM t_user_info WHERE uname = N'{0}' AND upwd = '{1}' ", TextName.Text.Trim(), SecPwd);
            SqlDataAdapter da = new SqlDataAdapter();  //创建一个空DataAdapter对象
            da.SelectCommand = new SqlCommand(SelectSql, Conn);
            DataSet ds = new DataSet();    //创建一个空dataSet
                                           //将AdtaAdapter执行SQL语句返回的结果填充到DataSet对象 
            da.Fill(ds);
            Conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                //如果返回的记录条数为0，则没有条件的用户
                Response.Write("<script>alert('用户名或密码错误！');</script>");
                return;
            }
            //从DataSet中得到要修改的行
            //DataRow MyRow = ds.Tables[0].Rows[0];
            //if (MyRow[3].ToString().Trim()=="admin")
            //{
            //    //如果索引值为3的列的值为admin
            //    Response.Write("<script>alert('你的级别是：管理员！');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('你的级别是：普通用户！');</script>");

            //}
            Session["userlevel"] = ds.Tables[0].Rows[0][3].ToString().Trim();
            Session["username"] = TextName.Text;
            Response.Redirect("~/Index2.aspx");
        }

        protected void LinkRePwd_Click(object sender, EventArgs e)
        {
            if (TextName.Text == "")
            {
                Response.Write("<script>alert('请输入用户名！');</script>");
                return;
            }
            //通过查询字符串将用户名传递给目标页面
            Response.Redirect(string.Format("~/Repwd.aspx?username={0}", TextName.Text));
        }

        protected void LinkEdit_Click(object sender, EventArgs e)
        {

            string ConnSql = ConfigurationManager.ConnectionStrings["ConnString2021"].ConnectionString;

            SqlConnection Conn = new SqlConnection(ConnSql);
            Conn.Open();
            //使用MD5算法加密用户口令
            //string SecPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(TextPwd.Text, "MD5");
            string SecPwd = Enocder.MD5Hash(TextPwd.Text);
            string SelectSql = string.Format(" SELECT * FROM t_user_info WHERE uname = N'{0}' AND upwd = '{1}' ", TextName.Text.Trim(), SecPwd);
            SqlDataAdapter da = new SqlDataAdapter();  //创建一个空DataAdapter对象
            da.SelectCommand = new SqlCommand(SelectSql, Conn);
            DataSet ds = new DataSet();    //创建一个空dataSet
                                           //将AdtaAdapter执行SQL语句返回的结果填充到DataSet对象 
            da.Fill(ds);
            Conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                //如果返回的记录条数为0，则没有条件的用户
                Response.Write("<script>alert('用户名或密码错误！');</script>");
                return;
            }

            //用户身份得到验证后，将用户级别和用户名保存到Session对象中
            Session["userlevel"] = ds.Tables[0].Rows[0][3].ToString().Trim();
            Session["username"] = TextName.Text;
            Response.Redirect("Update.aspx");
        }

    }
}