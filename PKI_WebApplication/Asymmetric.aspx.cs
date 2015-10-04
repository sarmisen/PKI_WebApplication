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
    public partial class Asymmetric : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private RSACryptoServiceProvider CreateCipher()
        {
            //Tenemos la posibilidad de utilizar un contenedor de claves RSA previamente generado (si no lo encuentra generará uno on-the-fly
            //CspParameters cp = new CspParameters();
            //cp.KeyContainerName = "RjbRsaKeys";
            //cp.Flags = CspProviderFlags.UseMachineKeyStore;
            //RSACryptoServiceProvider cipher = new RSACryptoServiceProvider(cp);

            //En esta demo utilizaremos el fichero xml que nos hemos generado previamente con aspnet_regiis
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher.FromXmlString("<RSAKeyValue><Modulus>rVhOcUJYsajc070Mw8okIHRFLrCqQvSKPipimY5zUcasVFmMqy+fgvEw6eJ3OeW700tyIIf6+n7FwZl2RbAaDsn706/OEjO1PaQgo/vgA1aGpucsTRMErNT85IGTd9wezUUPMaBcnRPo5BikuuAenPkbEiBPTHtuPeD/WH589M0=</Modulus><Exponent>AQAB</Exponent><P>1xvdke0vPPf+oibdbR8Is3Xt2HpR5McFJr9JX3B6YfKDqBxemsO3YuwDVCjEcgr97ul0zYczllI5UCpEmc8mbQ==</P><Q>zkwG/fgOI0Mew/VOeiuezB1bBt+Tla7f8j48oAp5pLVPF9xplDjhK3qb5nGqMu9crZHN2toyG3vz1FbEHmuL4Q==</Q><DP>k85p6SN5GgOty+24qIpyiB24WM90Bidaus0ltZasATGKlbEosF9bW3Wgs+tvUI2M/uUbhT4pjFjjWNoyWR2l4Q==</DP><DQ>rPIz0mpIf+tfOWzHk8hJ4lih3UtGEPCAMjdW39yoShrt6dUQdgCRVL//Ptv/kZ/1lFVtvJG7/CqYKWVsGQyUQQ==</DQ><InverseQ>VJAsmqt4FOnC3UbuHL2HTj83CdA+bZjDIkbqqZO2wlQorB+O8u22wJOSARhCIZj4p6ThOwBxJ8jgNGgaIQQHTQ==</InverseQ><D>DGDp+RyLyOQOIPC3IKQmwEqNRjBHeFCOLrJIKD8L7SMK21spuG/GLEuc+pa5fODy8LvKgpgzTAARjymuUHuq4JVkGwdkUQ5pAjRrjUerAsvuxSA53jv+tjSun8kahw+PV4R5fT4jZS9Dhjd09MykYjjLEL23t2teitNrEbdOtAE=</D></RSAKeyValue>");

            //Mostrar las claves en la cajita
            tbRSAKeys.Text = cipher.ToXmlString(true);

            return cipher;
        }
        protected void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider cipher = CreateCipher();


            //Convetir a bytes y encripta
            byte[] plaintext = System.Text.Encoding.UTF8.GetBytes(tbPlainText.Text);
            byte[] cipherText = cipher.Encrypt(plaintext, false);

            //Convertir a Base64 para mostrar
            tbCypherText.Text = Convert.ToBase64String(cipherText);
        }
        protected void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            RSACryptoServiceProvider cipher = CreateCipher();


            //Convetir a bytes y encripta
            byte[] original = cipher.Decrypt(Convert.FromBase64String(tbCypherText.Text), false);

            //Convertir a Base64 para mostrar
            tbNewPalinText.Text = System.Text.Encoding.UTF8.GetString(original);
        }
    }
}