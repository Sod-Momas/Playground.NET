<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MessageBoard.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <label><b>用户注册</b> </label>
    </div>

    <table class="table table-bordered">
        <tr>
            <td>
                <label>用户名</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextName" CssClass="form-control"></asp:TextBox><br />
                <asp:LinkButton runat="server" ID="LinkCheckName" OnClick="LinkCheckName_Click" CssClass="btn btn-xs btn-primary">检查用户名</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <label>密码</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextPwd" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>密码</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextConfirmPwd" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>电子邮件</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextEMail" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>安全问题</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextQuestion" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>安全问题答案</label>
            </td>
            <td>
                <asp:TextBox runat="server" ID="TextAnswer" CssClass="form-control"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:LinkButton runat="server" ID="LinkSubmit" OnClick="LinkSubmit_Click" CssClass="btn btn-success">提交</asp:LinkButton>
                <a type="button" href="Default.aspx" class="btn btn-default">后退</a>
            </td>
        </tr>
    </table>

</asp:Content>
