using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageRouter.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new WebClient();
            var filePath = Path.Combine(Path.GetTempPath(), "TestFile.txt");
            File.WriteAllText(filePath, "This is a test file for the Azure Storage Router");
            var result = client.UploadFile("http://localhost:42553/api/documents", filePath);
            var resultData = Encoding.UTF8.GetString(result);
            Console.WriteLine(resultData);
        }
    }
}
