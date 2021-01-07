using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AsymEncryptServ
{
    public class RSAParameterKey
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public void AssignNewKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;
            _publicKey = rsa.ExportParameters(false);
            _privateKey = rsa.ExportParameters(true);
        }

        public byte[] Encrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(_publicKey);

            return rsa.Encrypt(data, true);
        }

        public byte[] Decrypt(byte[] data)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048);
            rsa.PersistKeyInCsp = false;
            rsa.ImportParameters(_privateKey);

            return rsa.Decrypt(data, true);
        }

        public List<string> ListKeysData()
        {
            List<string> keysdata = new List<string>();
            keysdata.Add("Public Key:");
            keysdata.Add("Eksponent:");
            keysdata.Add(Convert.ToBase64String(_publicKey.Exponent));
            keysdata.Add("Modulus:");
            keysdata.Add(Convert.ToBase64String(_publicKey.Modulus));
            keysdata.Add("");
            // insert private key data to show off

            return keysdata;
        }
    }
}
