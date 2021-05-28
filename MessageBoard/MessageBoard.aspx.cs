using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace MessageBoard
{
    public partial class MessageBoard : System.Web.UI.Page
    {

        private SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnString2021"].ConnectionString);
        private DataSet dataSet = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            var name = Session["username"];
            var level = Session["userlevel"];
            if (name == null || level == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            Label1.Text = Session["username"].ToString();

        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Redirect("~/Default.aspx");
                return;
            }
            var name = Session["username"].ToString();

            if (TextBox1.Text.Trim().Length < 1)
            {
                Response.Write("<script>alert('请填写好留言内容！');</script>");
                return;
            }
            var msg = TextBox1.Text;


            conn.Open();
            var SelectSql = "SELECT * FROM t_message";
            SqlDataAdapter da = new SqlDataAdapter(SelectSql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            SqlCommandBuilder scb = new SqlCommandBuilder(da);
            DataRow MyRow = ds.Tables[0].NewRow();
            MyRow["muser"] = name;
            MyRow["mcontent"] = msg;
            MyRow["mtime"] = DateTime.Now;
            ds.Tables[0].Rows.Add(MyRow);
            try
            {

                da.Update(ds);
            }
            catch (Exception)
            {

                throw;
            }

            Response.Redirect("~/MessageBoard.aspx");
        }
        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["userlevel"] = null;

            Response.Redirect("~/Default.aspx");
        }
    }
}