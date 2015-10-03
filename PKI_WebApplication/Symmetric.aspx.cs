using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Web.Configuration;
using PKI_WebApplication.classes;

namespace PKI_WebApplication
{
    public partial class Symmetric : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private RijndaelManaged CreateCipher()
        {
            RijndaelManaged cipher = new RijndaelManaged();

            cipher.KeySize = 256;
            cipher.BlockSize = 256;
            cipher.Padding = PaddingMode.ISO10126;
            cipher.Mode = CipherMode.CBC;

            //No usar ninguno de estos
            //cipher.Padding = PaddingMode.Zeros;
            //cipher.Mode = CipherMode.ECB;

            //leer la clave del fichero de configuración
            byte[] key = conversions.StringToByteArray(WebConfigurationManager.AppSettings["AES256"]);
            cipher.Key = key;

            return cipher;
        }
        protected void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            RijndaelManaged cipher = CreateCipher();

            //Mostrar el IV en la página (será necesrio para desencriptar, normalmente enviado en plano con el texto cifrado)
            tbIV.Text = Convert.ToBase64String(cipher.IV);

            //Crea el encriptador, convetir a bytes y encripta
            ICryptoTransform cryptTransform = cipher.CreateEncryptor();
            byte[] plaintext = System.Text.Encoding.UTF8.GetBytes(tbPlainText.Text);
            byte[] cipherText = cryptTransform.TransformFinalBlock(plaintext, 0, plaintext.Length);

            //Convertir a Base64 para mostrar
            tbCypherText.Text = Convert.ToBase64String(cipherText);
        }
        protected void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            RijndaelManaged cipher = CreateCipher();

            //REcuperar el IV quie hemos creado previamente
            cipher.IV = Convert.FromBase64String(tbIV.Text);

            //Crea el encriptador, convetir a bytes y encripta
            ICryptoTransform cryptTransform = cipher.CreateDecryptor();
            byte[] cipherText = Convert.FromBase64String(tbCypherText.Text);
            byte[] plainText = cryptTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);

            //Convertir a Base64 para mostrar
            tbNewPalinText.Text =System.Text.Encoding.UTF8.GetString(plainText);
        }
    }
}