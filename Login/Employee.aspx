<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="Login_Employee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8">
    <title>emagictours | Log in</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no'
        name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="../css/AdminLTE.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
<div class="form-box" id="login-box">
        <div class="header">
            Employee Sign In</div>
    <form id="form1" runat="server">
          <div class="body bg-gray">
            <div class="form-group">
                <asp:TextBox ID="Txt_id" runat="server" CssClass="form-control" placeholder="User ID"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="Txt_pwd" runat="server" TextMode="Password" class="form-control" placeholder="Password"></asp:TextBox>
            </div>
           
        </div>
        <div class="footer">
             <asp:Button ID="Btn_submit" runat="server" Text="Sign me in" 
                 CssClass="btn bg-olive btn-block" onclick="Btn_submit_Click"/>
            <p>
                <a href="Forget_Pwd.aspx">I forgot my password</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<a href="https://emagictours.com">Back to Home page</a> </p>
        </div>
    </form>
    </div>
   <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.0.2/jquery.min.js"></script>
    
</body>
</html>
