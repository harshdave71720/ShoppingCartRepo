using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ShoppingSystemApiConsoleClient;
using KeyBasedAuthenticator;

namespace ShoppingSystemApiConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            int flag = 1;
            while (flag > 0) {
                string inputPath = @"C:\Users\Harshdeep SIngh\source\repos\harshdave71720\ShoppingCartRepo\ShoppingCartSolution\ShoppingSystemApiConsoleClient\HashCodeInput.txt";
                string outputPath = @"C:\Users\Harshdeep SIngh\source\repos\harshdave71720\ShoppingCartRepo\ShoppingCartSolution\ShoppingSystemApiConsoleClient\HashCodeOutput.txt";
                using (StreamReader reader = new StreamReader(new FileStream(inputPath, FileMode.Open, FileAccess.Read)))
                {

                    string rawData = "";
                    string[] arr = reader.ReadLine().Split(' ');
                    var secretKey = arr[1].Trim();
                    var userId = arr[0].Trim();
                    rawData += userId;
                    rawData += Guid.NewGuid().ToString("N");
                    rawData += Guid.NewGuid().ToString("N");

                    var hashSignature = HashSignatureGenerator.GenerateHash(rawData, secretKey);
                    //Console.WriteLine(hashSignature);
                    using (StreamWriter writer = new StreamWriter(new FileStream(outputPath, FileMode.Open, FileAccess.Write)))
                    {
                        writer.Write("Authorization Data =>" + rawData + ":" + hashSignature);
                    }
                }
                Console.WriteLine("Enter something to do again");
                flag = Console.Read();
            }
            
        }
    }
}
