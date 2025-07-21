using Resume_Builder_MAUI.Model;

namespace Resume_Builder_MAUI.ViewModel;

public class JobFetcher
{
    private static readonly HttpClient client = new();

    public static async Task<RemotiveJobsResponse?> RemotiveJobFetcher(string url)
    {
        try
        {
            var response = await client.GetStringAsync(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<RemotiveJobsResponse>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching jobs: {ex.Message}");
            return null;
        }
    }

    public static async Task<JSearchJobsResponse?> JSearchJobFetcher(string url)
    {
        try
        {
            try
            {
                string? apiKey = Environment.GetEnvironmentVariable("RAPIDAPI_KEY");
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new Exception("RAPIDAPI_KEY environment variable is not set.");
                }
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "jsearch.p.rapidapi.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JSearchJobFetcher | API Key: {ex.Message}");
            }

            var response = await client.GetStringAsync(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JSearchJobsResponse>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching jobs: {ex.Message}");
            return null;
        }
    }

    public static async Task<JSearchJobsResponse?> JSearchDetailJobFetcher(string url)
    {
        try
        {
            try
            {
                string? apiKey = Environment.GetEnvironmentVariable("RAPIDAPI_KEY");
                if (string.IsNullOrEmpty(apiKey))
                {
                    throw new Exception("RAPIDAPI_KEY environment variable is not set.");
                }
                client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);
                client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "jsearch.p.rapidapi.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in JSearchJobFetcher | API Key: {ex.Message}");
            }

            var response = await client.GetStringAsync(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JSearchJobsResponse>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching jobs: {ex.Message}");
            return null;
        }
    }
}

