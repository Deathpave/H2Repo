using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AsymEncryptServ
{
    class Program
    {
        static void Main(string[] args)
        {
            //RSAXml();
            //Console.ReadLine();
            RSAParameter();
            Console.ReadLine();
        }

        public static void RSAXml()
        {
            RSAXML rsa = new RSAXML();
            rsa.AssignNewKeys();
            Console.WriteLine("Insert encrypted text from other program");
            string input = Console.ReadLine();
            byte[] decrypted = rsa.Decrypt(Convert.FromBase64String(input));
            Console.WriteLine(Encoding.UTF8.GetString(decrypted));
        }

        public static void RSAParameter()
        {
            RSAParameterKey rSAParam = new RSAParameterKey();

            rSAParam.AssignNewKey();
            List<string> keysdata = rSAParam.ListKeysData();
            foreach (string line in keysdata)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("Insert encrypted text from other program!");
            string input = Console.ReadLine();

            byte[] decryptraw = Encoding.UTF8.GetBytes(input);
            byte[] decrypted = rSAParam.Decrypt(Convert.FromBase64String(input));
            Console.WriteLine("Decrypted text:\n" + Encoding.UTF8.GetString(decrypted));
        }
    }
}
