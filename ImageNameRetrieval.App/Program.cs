using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ImageNameRetrieval.Service;
using ImageNameRetrieval.Service.Models;

namespace ImageNameRetrieval.App
{
    internal class Program
    {
        static string pexelQuery;
        static int pexelAmount;
        static bool running = true;
        static async Task Main(string[] args)
        {
            while (running)
            {
                if (InputQuery() && InputAmount())
                {
                    try
                    {
                        var pexels = new PexelsService(new System.Net.Http.HttpClient());
                        var response = await pexels.GetImages(pexelQuery, pexelAmount);

                        // for loop to print the alt tag (name of the photo).
                        foreach (var image in response.Photos)
                        {
                            Console.WriteLine(image.Alt);
                        }
                        // Can prompt and continue to next pages if desired, rec. adding function for that.
                    }
                    catch
                    {
                        Console.WriteLine("No image names found.");
                    }
                }
                CloseApplication();
            }

            Console.WriteLine("Exiting the application. Press any key to close this window . . .");
            Console.ReadKey();
        }

        #region Input Handlers
        // Could export to a service for more indepth test coverage/portable code
        private static bool InputQuery()
        {
            bool validQuery = false;
            while(!validQuery)
            {

                Console.WriteLine("Image Search Query:");
                pexelQuery = Console.ReadLine();
                if (Regex.IsMatch(pexelQuery, "^[a-zA-Z0-9]+$")) // letters/numbers only in search
                {
                    validQuery = true;
                }
                else
                {
                    Console.WriteLine("Invalid response. Would you like to try again? (y/n): ");
                    string response = Console.ReadLine()?.ToLower();

                    if (response == "n")
                    {
                        return false;
                    }
                }
                    
            }
            return true;
        }

        private static bool InputAmount()
        {
            bool validAmount = false;
            while (!validAmount)
            {
                Console.WriteLine("Maximum search display (1-25):");
                if (int.TryParse(Console.ReadLine(), out pexelAmount) && pexelAmount >= 1 && pexelAmount <= 25)
                {
                    validAmount = true;
                }
                else
                {
                    Console.WriteLine("Invalid response. Would you like to try again? (y/n): ");
                    string response = Console.ReadLine()?.ToLower();

                    if (response == "n")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static void CloseApplication()
        {
            Console.WriteLine("Would you like to close the application? (y/n): ");
            string response = Console.ReadLine();

            if (response?.ToLower() == "y")
            {
                running = false;
            }
        }
        #endregion
    }
}