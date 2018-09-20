using Newtonsoft.Json.Linq;
using System;

namespace Payment.Gateway
{
    class Program
    {
        public static string END = "https://fts.cardconnect.com:6443";
        public static string USERNAME = "cardconnect";
        public static string PASSWORD = "cconnect!49";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


        public static String authTransaction()
        {
            Console.WriteLine("\nAuthorization Request");

            // Create Authorization Transaction request
            JObject request = new JObject();
            // Merchant ID
            request.Add("merchid", "123456789012");
            // Card Type
            request.Add("accttype", "VI");
            // Card Number
            request.Add("account", "4444333322221111");
            // Card Expiry
            request.Add("expiry", "0914");
            // Card CCV2
            request.Add("cvv2", "776");
            // Transaction amount
            request.Add("amount", "100");
            // Transaction currency
            request.Add("currency", "USD");
            // Order ID
            request.Add("orderid", "12345");
            // Cardholder Name
            request.Add("name", "Test User");
            // Cardholder Address
            request.Add("address", "123 Test St");
            // Cardholder City
            request.Add("city", "TestCity");
            // Cardholder State
            request.Add("region", "TestState");
            // Cardholder Country
            request.Add("country", "US");
            // Cardholder Zip-Code
            request.Add("postal", "11111");
            // Return a token for this card number
            request.Add("tokenize", "Y");

            // Create the REST client
            CardConnectRestClient client = new CardConnectRestClient(ENDPOINT, USERNAME, PASSWORD);

            // Send an AuthTransaction request
            JObject response = client.authorizeTransaction(request);

            foreach (var x in response)
            {
                String key = x.Key;
                JToken value = x.Value;
                Console.WriteLine(key + ": " + value.ToString());
            }

            return (String)response.GetValue("retref");
        }
    }
}
