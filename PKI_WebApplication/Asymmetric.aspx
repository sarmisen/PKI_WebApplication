<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Asymmetric.aspx.cs" Inherits="PKI_WebApplication.Asymmetric" ValidateRequest="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        input:not([type='button']) {
            border: 1px solid gray;
        }
        input {
            padding: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Ejemplo Encriptación Asimétrica</h1>
        <div style="float: left; width: 150px; padding: 5px;">Texto Plano</div>
        <div style="float:left; width: 400px; padding: 5px"><asp:TextBox ID="tbPlainText" runat="server" Width="100%"></asp:TextBox></div>
        <div style="float: left; width: 100px; padding: 5px;"><asp:Button ID="btEncrypt" runat="server" Width="100%" Text="Encriptar" OnClick="ButtonEncrypt_Click" /></div>
        <div style="clear: both; height: 0px;"></div>
        <div style="margin-top: 10px; background-color: #ccc;">
            <div style="float: left; width: 150px; padding: 5px;">Texto Cifrado</div>
            <div style="float:left; width: 400px; padding: 5px"><asp:TextBox ID="tbCypherText" runat="server" Width="100%" TextMode="MultiLine" Rows="8"></asp:TextBox></div>
            <div style="float: left; width: 100px; padding: 5px;"><asp:Button ID="btDecrypt" runat="server" Width="100%" Text="Des-encriptar" OnClick="ButtonDecrypt_Click" /></div>
            <div style="clear: both;"></div>
        </div>
            <div style="float: left; width: 150px; padding: 5px;">Nuevo texto plano</div>
            <div style="float:left; width: 400px; padding: 5px"><asp:TextBox ID="tbNewPalinText" runat="server" Width="100%"></asp:TextBox></div>
            <div style="clear: both;"></div>
            <div style="float: left; width: 150px; padding: 5px;">Claves RSA</div>
            <div style="float:left; width: 400px; padding: 5px"><asp:TextBox ID="tbRSAKeys" runat="server" Width="100%" TextMode="MultiLine" Rows="16"></asp:TextBox></div>
            <div style="clear: both;"></div>
    </div>
    </form>
</body>
</html>
