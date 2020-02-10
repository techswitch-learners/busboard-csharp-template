using System;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var client = new RestClient("https://api.tfl.gov.uk/");
            client.Authenticator = new HttpBasicAuthenticator("f8163132", "fc375759d5162e056d8437f676e78aef");

            //var request = new RestRequest("StopPoint/490008660N", DataFormat.Json);

            //var response = client.Get(request);
            
            Console.WriteLine("Type a bus stop code to see the next 5 buses at that stop");
            var busStop = Console.ReadLine();
            
            var nextFiveBusesRequest = new RestRequest($"StopPoint/{busStop}", DataFormat.Json);
            var nextFiveBusesResponse = client.Get(nextFiveBusesRequest);

            var responseString = nextFiveBusesResponse.ToString();

            foreach (var word in responseString)
            {
                Console.Write(word);
            }

            
        }
    }
}