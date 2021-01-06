using System;
using System.Collections.Generic;
using System.Text;

namespace SymmetricEncryption
{
    public interface IAlgorithm
    {
        public byte[] Encrypt(byte[] data, byte[] key, byte[] iv);
        public byte[] Decrypt(byte[] data, byte[] key, byte[] iv);
        public byte[] GenerateRandomNumber(int length);
    }
}
