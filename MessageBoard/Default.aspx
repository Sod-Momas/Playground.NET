<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MessageBoard._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>--%>

    <div class="row">

        <%--        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
        --%>

        <div class="row col-lg-6 col-lg-offset-3">
            <table class="table">
                <thead>
                    <tr>
                        <th colspan="2">
                            <label class="page-header">用户登录</label>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <label for="TextName">用户名</label></td>
                        <td>
                            <asp:TextBox ID="TextName" runat="server" CssClass=" form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="TextPwd">密码</label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextPwd" runat="server" TextMode="Password" CssClass=" form-control"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="LinkLogin" runat="server" OnClick="LinkLogin_Click" CssClass="btn btn-default btn-success">登录</asp:LinkButton>
                            &nbsp;
                <asp:LinkButton ID="LinkReg" runat="server" PostBackUrl="~/Register.aspx" CssClass="btn btn-default">注册</asp:LinkButton>
                            &nbsp;
                <asp:LinkButton ID="LinkRePwd" runat="server" OnClick="LinkRePwd_Click" CssClass="btn btn-danger">忘记密码</asp:LinkButton>
                            &nbsp;
                <asp:LinkButton ID="LinkEdit" runat="server" OnClick="LinkEdit_Click" CssClass="btn btn-info">修改信息</asp:LinkButton>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
