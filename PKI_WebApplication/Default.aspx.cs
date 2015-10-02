using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.HtmlControls;

namespace PKI_WebApplication
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string plaintext = "Esto es un ejemplo de demo de hassing";
            string plaintext2 = "En un lugar de la Mancha, de cuyo nombre no quiero acordarme, no ha mucho tiempo que vivía un hidalgo de los de lanza en astillero, adarga antigua, rocín flaco y galgo corredor. Una olla de algo más vaca que carnero, salpicón las más noches, duelos y quebrantos los sábados, lentejas los viernes, algún palomino de añadidura los domingos, consumían las tres partes de su hacienda. El resto della concluían sayo de velarte, calzas de velludo para las fiestas con sus pantuflos de lo mismo, los días de entre semana se honraba con su vellori de lo más fino. Tenía en su casa una ama que pasaba de los cuarenta, y una sobrina que no llegaba a los veinte, y un mozo de campo y plaza, que así ensillaba el rocín como tomaba la podadera. ";
            string plaintext3 = "In un lugar de la Mancha, de cuyo nombre no quiero acordarme, no ha mucho tiempo que vivía un hidalgo de los de lanza en astillero, adarga antigua, rocín flaco y galgo corredor. Una olla de algo más vaca que carnero, salpicón las más noches, duelos y quebrantos los sábados, lentejas los viernes, algún palomino de añadidura los domingos, consumían las tres partes de su hacienda. El resto della concluían sayo de velarte, calzas de velludo para las fiestas con sus pantuflos de lo mismo, los días de entre semana se honraba con su vellori de lo más fino. Tenía en su casa una ama que pasaba de los cuarenta, y una sobrina que no llegaba a los veinte, y un mozo de campo y plaza, que así ensillaba el rocín como tomaba la podadera. ";
            Response.Write("<p />" + plaintext + " <p /><b>Hashes to</b><p /> " + doHash(plaintext));
            Response.Write("<p />" + plaintext2 + " <p /><b>Hashes to</b><p /> " + doHash(plaintext2));
            Response.Write("<p />" + plaintext3 + " <p /><b>Hashes to</b><p /> " + doHash(plaintext3));
        }

        private string doHash(string plaintext)
        {
            SHA512Managed hashSvc = new SHA512Managed();

            //SHA512 returns 512 bits (8bits/byte, 64bytes) for the hash
            byte[] hash = hashSvc.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

            //This converts the 64 byte hash into the string hex representation of bytevalues
            // (shown by default as 2 hex characters per byte) that looks like
            // "FB-2F-85-C8-85-67-F3", each pair represents the byte value of 0-255
            //Removing the "-" separator creates a 128 character string representation in hex

            string hex = BitConverter.ToString(hash).Replace("-", "");
            return hex;

        }
    }
}