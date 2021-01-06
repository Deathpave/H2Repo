using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace SymmetricEncryption
{
    public class TDES : IAlgorithm
    {
        public byte[] GenerateRandomNumber(int length)
        {
            RandomNumberGenerator randomNumber = RandomNumberGenerator.Create();
            byte[] number = new byte[length];
            randomNumber.GetBytes(number);
            return number;
        }

        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Mode = CipherMode.CBC;
            tripleDES.Padding = PaddingMode.PKCS7;
            tripleDES.Key = key;
            tripleDES.IV = iv;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, tripleDES.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return ms.ToArray();
        }

        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            TripleDES tripleDES = TripleDES.Create();
            tripleDES.Mode = CipherMode.CBC;
            tripleDES.Padding = PaddingMode.PKCS7;
            tripleDES.Key = key;
            tripleDES.IV = iv;

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, tripleDES.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(data, 0, data.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return ms.ToArray();
        }
    }
}
