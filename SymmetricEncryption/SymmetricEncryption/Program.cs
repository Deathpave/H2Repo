using System;
using System.Diagnostics;

namespace SymmetricEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            IAlgorithm algorithm = null;
            int keylength = 0;
            int ivlength = 0;

            Console.WriteLine("Choose algorithm\n1:AES\n2:3DES\n3:DES");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    algorithm = new AES();
                    keylength = 32;
                    ivlength = 16;
                    break;
                case 2:
                    algorithm = new TDES();
                    keylength = 16;
                    ivlength = 8;
                    break;
                case 3:
                    algorithm = new DES();
                    keylength = 8;
                    ivlength = 8;
                    break;
            }

            string encryptme = Console.ReadLine();

            stopwatch.Start();
            byte[] key = algorithm.GenerateRandomNumber(keylength);
            byte[] iv = algorithm.GenerateRandomNumber(ivlength);


            byte[] encrypted = algorithm.Encrypt(Convert.FromBase64String(encryptme), key, iv);
            byte[] decrypted = algorithm.Decrypt(encrypted, key, iv);
            stopwatch.Stop();

            Console.WriteLine(Convert.ToBase64String(encrypted));
            Console.WriteLine(BitConverter.ToString(encrypted));
            Console.WriteLine(Convert.ToBase64String(decrypted));
            Console.WriteLine(BitConverter.ToString(decrypted));
            Console.WriteLine("Total time taken: " + stopwatch.ElapsedMilliseconds + " milliseconds");
            Console.ReadLine();
        }
    }
}