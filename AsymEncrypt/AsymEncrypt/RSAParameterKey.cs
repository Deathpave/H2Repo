using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AsymEncrypt
{
    public class RSAParameterKey
    {
        private RSAParameters _publicKey;
        private RSAParameters _privateKey;

        public void AssignPublic(byte[] exponent, byte[] modulus)
        {
            _publicKey.Exponent = exponent;
            _publicKey.Modulus = modulus;
        }

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
    }
}
