using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageBoard
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LinkCheckName_Click(object sender, EventArgs e)
        {
            string username = TextName.Text.Trim();
            var exsited = DataHelper.CheckExsit(username);
            var msg = exsited ? "<script>alert('用户已被注册！');</script>" : "<script>alert('用户名可用！');</script>";
            Response.Write(msg);
        }


        protected void LinkSubmit_Click(object sender, EventArgs e)
        {
            if (TextName.Text.Length < 1 ||
                TextPwd.Text.Length < 1 ||
                TextConfirmPwd.Text.Length < 1 ||
                TextEMail.Text.Length < 1 ||
                TextQuestion.Text.Length < 1 ||
                TextAnswer.Text.Length < 1
                )
            {
                Response.Write("<script>alert('请将信息填写完整！');</script>");
                return;
            }

            if (TextPwd.Text != TextConfirmPwd.Text)
            {
                Response.Write("<script>alert('再次密码不一致！');</script>");
                TextConfirmPwd.Focus();
                return;
            }

            var userN = TextName.Text.Trim();
            var pwd = TextConfirmPwd.Text;

            if (DataHelper.CheckExsit(userN))
            {
                Response.Write("用户已经存在！请更换用户名！");
                TextName.Focus();
                return;
            }
            //把数据添加到数据库里
            var sucess = DataHelper.AddUser(userN, pwd, this.TextEMail.Text, this.TextQuestion.Text, this.TextAnswer.Text);
            Response.Write(sucess ? "<script>alert('用户注册成功')</script>" : "<script>alert('用户注册失败！请联系管理员或稍后再试')</script>");
        }
    }
}