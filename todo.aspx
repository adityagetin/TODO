<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="todo.aspx.cs" Inherits="WebApplication1.todo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/todo.css" />
</head>
<body>
    <h2>My List</h2>
    <form id="form1" runat="server">
        <div class="top">
        <div class="Date select">
            <div calss ="ip">
                <h2>Select Date:</h2>
                <asp:TextBox runat="server" TextMode="Date" ID="dateselect"  CssClass="input"></asp:TextBox>
                <asp:Button runat="server" Text="Set" CssClass="btn" id="set" OnClick="set_Click" />
            </div>
        </div>
        <div class="Add">
            <h2>Add Taks:</h2>
            <asp:TextBox runat="server" ID="task" CssClass="input"></asp:TextBox>
            <asp:Button runat="server" Text="Add" CssClass="btn" id="add" OnClick="add_Click"/>
            
        </div>
        </div>
        <div class="Tables">
            <div class="pend">
                <h2>Pending Tasks:</h2>
                <table>
                    
                    <tr>
                        <th>Task</th>
                        <th>Action</th>
                    </tr>
                    <asp:Repeater ID="pendings" runat="server" OnItemCommand="table_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <th><%#Eval("work") %></th>
                                <th>
                                    <asp:Button ID="Done" runat="server" Text="DONE"  CssClass="btn"  CommandName="Done" CommandArgument=<%#Eval("work") %> />
                                    <asp:Button ID="Delete" runat="server" Text="Delete"  CssClass="btn"  CommandName="Delete" CommandArgument=<%#Eval("work") %> />
                                </th>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="comp">
                <h2>Complete Tasks:</h2>
                <table>
                    <tr>
                        <th>Task</th>
                    </tr>
                    <asp:Repeater ID="completed" runat="server" >
                        <ItemTemplate>
                            <tr>
                                <th><%#Eval("work") %></th>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
        <a href="Default.aspx" class="button-link" >LogOut!</a>
    </form>
</body>
</html>
