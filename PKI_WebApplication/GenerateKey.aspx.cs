using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PKI_WebApplication.classes;
namespace PKI_WebApplication
{
    public partial class GenerateKey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            byte[] key = new byte[32]; //256 bits (1 byte = 8 bits)

            //Generar el numero solicitado de bytes aleatorios
            crypto.GenRandomBytes(key);

            //Convertir a hex para almacenado de clave
            litKey.Text = conversions.ByteArrayToString(key);
        }
    }
}