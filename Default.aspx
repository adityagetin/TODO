<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<!DOCTYPE html>
<html xmls="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>My-ToDo</title>
        <link type="text/css" rel="stylesheet" href="Styles/default.css" />
        <script src="Scripts/default.js"></script>
    </head>
    <body>
        <h2>My ToDo</h2>
            <form runat="server">
                <div class="forms">
                    <div class="signup">
    <h3>Sign Up</h3>
    <div class="input">
        <asp:Label ID="mail" runat="server" Text="E-mail:" CssClass="lable"></asp:Label>
        <asp:TextBox ID="mainInput" runat="server" CssClass="inputbox"></asp:TextBox>
    </div>
    <div class="input">
        <asp:Label ID="name" runat="server" Text="Name:" CssClass="lable"></asp:Label>
        <asp:TextBox ID="nameInput" runat="server" CssClass="inputbox"></asp:TextBox>
    </div>
    <div class="input">
        <asp:Label ID="pass" runat="server" Text="Password:" CssClass="lable"></asp:Label>
        <asp:TextBox ID="passInput" runat="server" CssClass="inputbox"></asp:TextBox>
    </div>
    <div class="input">
        <asp:Label ID="repass" runat="server" Text="Re-Password:" CssClass="lable"></asp:Label>
        <asp:TextBox ID="repassInput" runat="server" CssClass="inputbox"></asp:TextBox>
    </div>
    <div class="btn">
        <asp:Button ID="signin" runat="server" Text="SignUp" CssClass="buttons" OnClick="signin_Click" />
        <asp:Label ID="signError" runat="server" CssClass="errors"></asp:Label>
    </div>
</div>
<div class="login">
    <h3>Log In</h3>
    <div class="input">
        <asp:Label ID="Lmail" runat="server" Text="E mail:" CssClass="lable"></asp:Label>
        <asp:TextBox ID="mailin" runat="server" CssClass="inputbox"></asp:TextBox>
    </div>
    <div class="input">
        <asp:Label ID="Lpass" runat="server" Text="Password:" CssClass="lable"></asp:Label>
        <asp:TextBox ID="passin" runat="server" CssClass="inputbox"></asp:TextBox>
    </div>
    <div class="btn">
        <asp:Button ID="log" runat="server" Text="LogIn" CssClass="buttons" OnClick="log_Click" />
        <asp:Label ID="logError" runat="server" CssClass="errors"></asp:Label>
    </div>
</div>
                </div>
                
            </form>
    </body>
</html>
