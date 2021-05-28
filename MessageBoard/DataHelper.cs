using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MessageBoard
{
    /// <summary>
    /// 用于数据库连接的通用类
    /// </summary>
    public class DataHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnString2021"].ConnectionString;

        public static bool CheckExsit(string username)
        {
            //设置Conn对象的连接字符串
            //声明Conn为一个SQL Server连接对象
            SqlConnection Conn = new SqlConnection(connectionString);

            Conn.Open();
            string SelectSql = string.Format(" SELECT * FROM t_user_info WHERE uname = N'{0}'", username.Trim());
            SqlDataAdapter da = new SqlDataAdapter();  //创建一个空DataAdapter对象
            da.SelectCommand = new SqlCommand(SelectSql, Conn);
            DataSet ds = new DataSet();    //创建一个空dataSet
                                           //将AdtaAdapter执行SQL语句返回的结果填充到DataSet对象 
            da.Fill(ds);
            Conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                //如果返回的记录条数为0，则没有条件的用户
                //Response.Write("<script>alert('用户名或密码错误！');</script>");
                return false;
            }
            return true;
        }

        public static bool CheckLogin(string username, string password)
        {
            //声明Conn为一个SQL Server连接对象
            SqlConnection Conn = new SqlConnection(connectionString);

            Conn.Open();
            //使用MD5算法加密用户口令
            string SecPwd = Encoder.MD5Hash(password);
            string SelectSql = string.Format(" SELECT * FROM t_user_info WHERE uname = N'{0}' AND upwd = '{1}' ", username.Trim(), SecPwd);
            SqlDataAdapter da = new SqlDataAdapter();  //创建一个空DataAdapter对象
            da.SelectCommand = new SqlCommand(SelectSql, Conn);
            DataSet ds = new DataSet();    //创建一个空dataSet
                                           //将AdtaAdapter执行SQL语句返回的结果填充到DataSet对象 
            da.Fill(ds);
            Conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                //如果返回的记录条数为0，则没有条件的用户
                //Response.Write("<script>alert('用户名或密码错误！');</script>");
                return false;
            }

            return true;
        }

        public static bool AddUser(string Username, string Password, string Email, string Question, string Answer)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter()
            {
                SelectCommand = new SqlCommand("SELECT * FROM t_user_info", conn)
            };
            DataSet ds = new DataSet();
            SqlCommandBuilder scd = new SqlCommandBuilder(da);
            //为DataAdapter自动生成更新命令
            da.Fill(ds);

            //填充dataSet对象
            DataRow NewRow = ds.Tables[0].NewRow();
            //向DataSet第一个表对象中添加一个新行
            NewRow["uname"] = Username;
            NewRow["upwd"] = Encoder.MD5Hash(Password);
            //用MD5加密算法加密密码
            NewRow["uemail"] = Email;
            NewRow["ulevel"] = "user";//通过注册页面添加的所有用户都是普通用户级别
            NewRow["uquestion"] = Question;
            NewRow["uanswer"] = Encoder.MD5Hash(Answer);
            //用MD5加密算法加密问题答案
            try
            {
                ds.Tables[0].Rows.Add(NewRow);
                //将NewRow添加到ds的第一个表对象中
                da.Update(ds);
                //将DataSet中数据变化提交到数据库(更新数据库)
            }
            catch (Exception)
            {
                return false;//如果有异常出现说明添加失败
            }

            conn.Close();
            return true;
        }

        public static DataSet SelectAll(string sql)
        {
            var ds = new DataSet();
            var da = new SqlDataAdapter(sql, connectionString);
            da.Fill(ds);
            return ds;
        }

        public static void InsertMsg(string username, string msg)
        {
            var ConnString = new SqlConnection(connectionString);
            var SelectSql = "SELECT * FROM t_message";
            var ds = new DataSet();

            ConnString.Open(); //打开数据库连接        
            var da = new SqlDataAdapter(SelectSql, ConnString);//执行查询
            da.Fill(ds);  //将数据全部装入ds
            ConnString.Close();//关闭数据库连接

            var scb = new SqlCommandBuilder(da);
            DataRow MyRow = ds.Tables[0].NewRow();

            MyRow["muser"] = username;
            MyRow["mcontent"] = msg;
            MyRow["mtime"] = DateTime.Now;

            ds.Tables[0].Rows.Add(MyRow);
            try
            {
                da.Update(ds);
            }
            catch (Exception)
            {
                throw new Exception("数据更新失败");
            }
        }
    }
}