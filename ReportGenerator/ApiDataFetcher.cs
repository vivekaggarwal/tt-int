using Newtonsoft.Json;

namespace ReportGenerator
{
    // Wrapper class to deserialize the 'values' node from the JSON
    public class ApiResponse<T>
    {
        [JsonProperty("values")]
        public List<T> Values { get; set; } = new List<T>();
    }

    public class ApiDataFetcher<T> : IDataFetcher<T>
    {
        public async Task<List<T>?> FetchDataAsync(string url)
        {
            using HttpClient client = new HttpClient();
            try
            {
                var response = await client.GetStringAsync(url);

                // Deserialize the response to access the 'values' node
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(response);

                return apiResponse?.Values; // Return only the 'values' node
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data from {url}: {ex.Message}");
                return null;
            }
        }
    }
}
