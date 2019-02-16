<%@ Page Language="C#" AutoEventWireup="true"  CodeBehind="Default.aspx.cs" Inherits="webAppTest._Default"
  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <script type="text/javascript">
         function GetNumber() {
             UseCallback();
         }
         function GetRandomNumberFromServer(TextBox1, context) {
             document.forms[0].TextBox1.value = TextBox1;
         }
  </script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        <%--<asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" /><br />--%>
        <%--<asp:Button ID="Button1" runat="server" Text="Button" UseSubmitBehavior="true" 
            OnClick="Button1_Click" oncommand="Buttonasdf_Command" /><br/>--%>
         <asp:Button ID="Button1" runat="server" Text="Button" /><br/>
         <input id="Button2" type="button" value="Случайное число" onclick="GetNumber()" /><br/>
        <asp:Label ID="Label1" runat="server" Text="Label1"></asp:Label><br />
        <asp:Label ID="Label2" runat="server" Text="Label2"></asp:Label><br />
        <asp:Label ID="Label3" runat="server" Text="Label3"></asp:Label><br />
        <asp:Label ID="Label4" runat="server" Text="Label3"></asp:Label><br />
        <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LinkButton</asp:LinkButton>    
    <asp:Image ID="Image1" runat="server" />
    </div>
    
    </form>
</body>
</html>
