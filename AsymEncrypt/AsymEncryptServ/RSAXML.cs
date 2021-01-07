using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AsymEncryptServ
{
    public class RSAXML
    {
        public void AssignNewKeys()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;

            File.WriteAllText(@"C:\Users\MartinRiehnMadsen\Desktop\cryptofolder\PublicKey.xml", rsa.ToXmlString(false));
            File.WriteAllText(@"C:\Users\MartinRiehnMadsen\Desktop\cryptofolder\PrivateKey.xml", rsa.ToXmlString(true));
        }

        public byte[] Decrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;
            rsa.FromXmlString(File.ReadAllText(@"C:\Users\MartinRiehnMadsen\Desktop\cryptofolder\PrivateKey.xml"));

            return rsa.Decrypt(data, true);
        }
    }
}
