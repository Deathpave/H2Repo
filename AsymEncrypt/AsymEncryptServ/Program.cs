using System;
using System.Collections.Generic;
using System.Text;

namespace AsymEncryptServ
{
    class Program
    {
        static void Main(string[] args)
        {
            RSAParameter();
            Console.ReadLine();
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

            byte[] decrypted = rSAParam.Decrypt(Convert.FromBase64String(input));
            Console.WriteLine("Decrypted text:\n" + Encoding.UTF8.GetString(decrypted));
        }
    }
}
