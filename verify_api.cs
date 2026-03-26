using System.Net.Http;
using System.Threading.Tasks;
using System;

var client = new HttpClient();

async Task Test(string query, string header)
{
    var url = $"http://localhost:5000/car{query}";
    var request = new HttpRequestMessage(HttpMethod.Get, url);
    if (!string.IsNullOrEmpty(header))
    {
        request.Headers.Add("X-Culture", header);
    }
    
    var response = await client.SendAsync(request);
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"Request: {url} (Header: {header})");
    Console.WriteLine($"Response: {content}");
    Console.WriteLine();
}

Console.WriteLine("--- Testing Query Parameter (lang=nl) ---");
await Test("?lang=nl", "");

Console.WriteLine("--- Testing Custom Header (X-Culture: nl) ---");
await Test("", "nl");

Console.WriteLine("--- Testing Default (en-US) ---");
await Test("", "");
