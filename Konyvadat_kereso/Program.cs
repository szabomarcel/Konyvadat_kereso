using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using konyv;

namespace Konyvadat_kereso
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Adja meg az ISBN könyv számát:");
            string isbn = Console.ReadLine();
            await book(isbn);
            Console.ReadLine();
        }

        private static async Task book(string isbn)
        {
            string apiUrl = $"https://www.goodreads.com/book/isbn/isbn?key=apiKey";
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Itt feldolgozhatod a jsonResponse-t, például kiírhatod a konzolra
                    Console.WriteLine(jsonResponse);
                }
                else
                {
                    Console.WriteLine("Hiba történt a kérés során.");
                }
            }
        }
    }
}
