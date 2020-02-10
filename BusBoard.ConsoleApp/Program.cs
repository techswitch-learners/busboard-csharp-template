using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var client = new RestClient("https://api.tfl.gov.uk");
            client.Authenticator = new HttpBasicAuthenticator("f8163132", "fc375759d5162e056d8437f676e78aef");

            //var request = new RestRequest("StopPoint/490008660N", DataFormat.Json);

            //var response = client.Get(request);
            
            Console.WriteLine("Type a bus stop code to see the next 5 buses at that stop");
            var busStop = Console.ReadLine();
            
            var nextFiveBusesRequest = new RestRequest($"/StopPoint/{busStop}/Arrivals", DataFormat.Json);
            var nextFiveBusesResponse = client.Get<List<Bus>>(nextFiveBusesRequest);

            var data = nextFiveBusesResponse.Data;
            var fiveBuses = data.Take(5);

            foreach (var bus in fiveBuses)
            {
                Console.WriteLine(bus.LineName);
            }
            
            /*foreach (var item in nextFiveBusesResponse.Data)
            {
                var lineName = item.LineName;
                Console.WriteLine(lineName);
            }*/
        }
    }
}