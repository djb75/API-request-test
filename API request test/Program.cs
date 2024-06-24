namespace API_request_test
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            const string symbol = "AAPL";
            const string apiKey = "cpqm2t9r01qo647nr5igcpqm2t9r01qo647nr5j0";
            const string url = "https://finnhub.io/api/v1/stock/";

            const string baseApi = $"https://finnhub.io/api/v1/quote?symbol={symbol}&token={apiKey}";

            try
            {
                var apiResponse = await client.GetAsync(baseApi);
                apiResponse.EnsureSuccessStatusCode();

                var apiResponseBody = await apiResponse.Content.ReadAsStringAsync();
                Console.WriteLine("AAPL data: ");
                Console.WriteLine(apiResponseBody);
            }

            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
