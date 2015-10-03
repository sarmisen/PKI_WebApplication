<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PKI_WebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        p {
            width: 500px;
            padding: 0px;
            margin-bottom: 10px;
            background-color:#CCC;
        }

        p a {
            width: 100%;
            display: block;
            padding: 5px;
            text-decoration: none;
        }
        p a:hover {
            background-color: #333;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <p><a href="GenerateKey.aspx">Generar clave</a></p>
    <p><a href="Hash.aspx">Hashing</a></p>
    <p><a href="Symmetric.aspx">Criptografía simétrica</a></p>
    </div>
    </form>
</body>
</html>
