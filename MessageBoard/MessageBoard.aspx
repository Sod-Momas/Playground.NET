<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageBoard.aspx.cs" Inherits="MessageBoard.MessageBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="page-header text-center">
        <label>用户留言</label>
    </div>

    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False"
        CssClass="table table-hover table-bordered text-center">
        <Columns>
            <asp:BoundField DataField="muser" HeaderText="用户名" SortExpression="muser" HeaderStyle-CssClass="text-center col-xs-2 " />
            <asp:BoundField DataField="mtime" HeaderText="留言时间" SortExpression="mtime" HeaderStyle-CssClass="text-center col-xs-1" />
            <asp:BoundField DataField="mcontent" HeaderText="留言内容" SortExpression="mcontent" HeaderStyle-CssClass="text-center" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnString2021 %>"
        SelectCommand="SELECT [muser], [mcontent], [mtime] FROM [t_message]"></asp:SqlDataSource>
    <div class="page-header text-center">
        <label>我要留言</label>
    </div>
    <table class="table table-bordered">
        <tbody>
            <tr>
                <td>
                    <label>留言人</label>
                </td>
                <td>
                    <label>
                        <asp:Label ID="Label1" runat="server" Text="(未知)"></asp:Label></label>
                </td>
            </tr>
            <tr>
                <td style="width: 80px;" rowspan="2">&nbsp;
                </td>
                <td>
                    <form  class="form-group">

                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Rows="6" CssClass="form-control" placeholder="填写留言内容"></asp:TextBox>
                    </form>
                </td>
            </tr>
            <tr>
                <td>

                    <asp:Button ID="BtnSubmit" runat="server" Text="提交" OnClick="BtnSubmit_Click" CssClass="btn btn-success pull-left" />
                    <asp:Button ID="BtnExit" runat="server" Text="退出" CssClass="btn btn-link pull-right"
                        OnClick="BtnExit_Click" />
                </td>
            </tr>
        </tbody>
    </table>
</div>
</asp:Content>
