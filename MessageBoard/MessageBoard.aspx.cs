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
            var dataAdapter = new SqlDataAdapter(" SELECT * FROM t_message ", conn);
            dataAdapter.Fill(dataSet);
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

            DataHelper.InsertMsg(name, TextBox1.Text);
            Response.Redirect("~/MessageBoard.aspx");//指向自己，刷新界面
        }
        protected void BtnExit_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Session["userlevel"] = null;

            Response.Redirect("~/Default.aspx");
        }
    }
}