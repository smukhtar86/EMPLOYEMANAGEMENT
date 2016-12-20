<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login_Login" %>

<!DOCTYPE html>
<html class="bg-black">
<head>
    <meta charset="UTF-8">
    <title><%= System.Configuration.ConfigurationManager.AppSettings["Domain"].ToString() %> | Log in</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'
        name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->
</head>
<body class="bg-black">
    <div class="form-box" id="login-box">
        <div class="header">
            Sign In</div>
        <form runat="server">
        <div class="body bg-gray">
             <div class="form-group">
                <asp:DropDownList ID="ddlType" runat="server" class="form-control" ></asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:TextBox ID="Txt_id" runat="server" CssClass="form-control" placeholder="User ID"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="Txt_pwd" runat="server" TextMode="Password" class="form-control" placeholder="Password"></asp:TextBox>
            </div>
        </div>
        <div class="footer">
             <asp:Button ID="Btn_submit" runat="server" Text="Sign me in" 
                 onclick="Btn_submit_Click" CssClass="btn bg-olive btn-block"/>
            <p>
                <a href="Forget_Pwd.aspx">I forgot my password</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<a href="<%=System.Configuration.ConfigurationManager.AppSettings["WebName"].ToString() %> ">Back to Home page</a> </p> 
        </div>
        </form>
       
    </div>
    <!-- jQuery 2.0.2 -->
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
    <!-- Bootstrap -->
</body>
</html>
