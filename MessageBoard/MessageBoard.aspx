<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageBoard.aspx.cs" Inherits="MessageBoard.MessageBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="MsgContent">
        <div class="page-header text-center">
            <label>留言板</label>
        </div>
        <table class="table table-bordered table-hover">
            <tbody>
                <tr class="text-center">
                    <td>留言用户</td>
                    <td>留言内容</td>
                    <td>留言时间</td>
                </tr>
                <% for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {     %>
                <% var row = dataSet.Tables[0].Rows[i]; %>
                <tr>
                    <td><% row["muser"].ToString(); %> </td>
                    <td><% row["mcontent"].ToString(); %></td>
                    <td><% row["mtime"].ToString();  %></td>
                </tr>
                <%   }   %>
            </tbody>

        </table>
    </div>

    <div id="Reply">
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
                        <asp:TextBox ID="TextBox1" runat="server" Width="99%" TextMode="MultiLine" Rows="6" CssClass="form-control" placeholder="填写留言内容"></asp:TextBox>
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
