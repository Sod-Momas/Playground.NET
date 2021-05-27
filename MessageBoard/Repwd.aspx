<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Repwd.aspx.cs" Inherits="MessageBoard.Repwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <label><b>找回遗忘密码</b></label>
    </div>
    <table class="table table-bordered">
        <tbody>
            <tr>
                <td>
                    <label>用户名</label>
                </td>
                <td>
                    <asp:Label runat="server" ID="LabelName" CssClass=" text-info"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>安全问题</label>
                </td>
                <td>
                    <asp:Label runat="server" ID="LabelQuestion" CssClass="text-info"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>安全问题答案</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextAnswer" CssClass="form-control "></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton runat="server" Text="提交" ID="LinkOk" OnClick="LinkOk_Click" CssClass="btn btn-success"></asp:LinkButton>
                    <a href="Default.aspx" class="btn btn-default">返回</a>
                </td>
            </tr>

        </tbody>
    </table>
</asp:Content>
