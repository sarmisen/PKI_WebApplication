using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace PKI_WebApplication.classes
{
    public static class crypto
    {
        public static void GenRandomBytes(byte[] buffer)
        {
            //utiliza un generador de numeros aleatorios criptografico fuerte
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            //Obten los suficientes bytes aleatorios para rellenar el buffer dad
            rng.GetBytes(buffer);
        }
    }
}