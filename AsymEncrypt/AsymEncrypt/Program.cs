using System;
using System.Text;

namespace AsymEncrypt
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
            RSAParameterKey rsa = new RSAParameterKey();
            Console.WriteLine("Insert public key exponent");
            byte[] exponent = Convert.FromBase64String(Console.ReadLine());
            Console.WriteLine("Insert public key modulus");
            byte[] modulus = Convert.FromBase64String(Console.ReadLine());
            rsa.AssignPublic(exponent, modulus);
            Console.WriteLine("Insert text to encrypt");
            string input = Console.ReadLine();
            byte[] encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(input));
            Console.WriteLine(Convert.ToBase64String(encrypted));
        }
    }
}
