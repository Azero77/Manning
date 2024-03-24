namespace LanguageFeatures.Models
{
    public class AsyncMethods
    {
        public static async Task<long?> GetPageLength()
        {
            var client = new HttpClient();
            var content = await client.GetAsync("http://manning.com");
            return content.Content.Headers.ContentLength;
        }

        public static async IAsyncEnumerable<long?> GetPageLengths(List<string> output , params string[] urls)
        {
            var httpClient = new HttpClient();
            
            foreach (string url in urls) 
            {
                output.Add($"Started Reading {url}...");
                var result = await httpClient.GetAsync($"http://{url}");
                output.Add($"Ended Fetching {url}");
                yield return result.Content.Headers.ContentLength;
            }
            
        }
    }
}
