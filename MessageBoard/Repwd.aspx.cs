using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MessageBoard
{
    public partial class Repwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["username"] == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
            //将登录页传来的用户名显示到标签控件中
            LabelName.Text = Request.QueryString["username"];
            var ConnString = ConfigurationManager.ConnectionStrings["ConnString2021"].ConnectionString;
            var Conn = new SqlConnection(ConnString); //声明新对象
            var SelectSql = string.Format("SELECT * FROM t_user_info WHERE uname=N'{0}' ", LabelName.Text);
            Conn.Open();//打开链接
            var da = new SqlDataAdapter();//创建空适配器
            da.SelectCommand = new SqlCommand(SelectSql, Conn);
            var ds = new DataSet();  //创建新数据集
                                     //将适配器里的东西填充到数据集里
            da.Fill(ds);
            Conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                //没有对象！行数为0
                Response.Write("<script>alert('用户名不存在！');history.back();</script>");
                return;
            }

            var MyRow = ds.Tables[0].Rows[0];//得到用户名的记录;
                                             //将记录里的第5个字段(安全问题)值显示到标签控件中
            LabelQuestion.Text = MyRow[4].ToString().Trim();
        }

        protected void LinkOk_Click(object sender, EventArgs e)
        {
            var ConnSql = ConfigurationManager.ConnectionStrings["ConnString2021"].ConnectionString;
            var Conn = new SqlConnection(ConnSql);//声明一个sql连接对象
            var SelectSql = String.Format(" SELECT * FROM t_user_info WHERE uname=N'{0}'", LabelName.Text);
            var da = new SqlDataAdapter();//创建空DataAdapter对象
            var ds = new DataSet();//创建空ds对象
            var msg = "<script>alert('答案错误！');</script>";
            Conn.Open();
            da.SelectCommand = new SqlCommand(SelectSql, Conn);
            da.Fill(ds);
            var SecAnswer = Enocder.MD5Hash(TextAnswer.Text);
            var MyRow = ds.Tables[0].Rows[0];
            if (SecAnswer == MyRow["uanswer"].ToString().Trim())
            {
                //如果填写答案加密与数据库内答案一致，则正确
                var scb = new SqlCommandBuilder(da);
                Random r = new Random();
                var NewPwd = r.Next(100000, 999999).ToString();//产生一个6位数的随机密码
                msg = string.Format("<script>alert('您的新密码是{0}');</script>", NewPwd);
                NewPwd = Enocder.MD5Hash(NewPwd);
                MyRow["upwd"] = NewPwd;//将经过MD5加密后的新密码写入DataSet
                da.Update(ds);  //将DataSet中的数据变化提交到数据库
                Conn.Close();
            }
            Response.Write(msg);

        }
    }
}