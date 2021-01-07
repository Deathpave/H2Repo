using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AsymEncrypt
{
    public class RSAXML
    {
        public byte[] Encrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(File.ReadAllText(@"C:\Users\MartinRiehnMadsen\Desktop\cryptofolder\PublicKey.xml"));

            return rsa.Encrypt(data, true);
        }
    }
}
