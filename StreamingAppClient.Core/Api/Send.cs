using StreamingAppClient.Core.VtubeStudio.Props;
using System.Text;
using System.Text.Json;

namespace StreamingAppClient.Core.Api;

public class Send : ISend
{
    public async Task SendToServer(VtubeStudioData vtubeStudioData)
    {
        StringContent content = new(JsonSerializer.Serialize(vtubeStudioData), Encoding.UTF8, "application/json");

        string stringResponse = await content.ReadAsStringAsync();

        try
        {
            HttpResponseMessage response = await new HttpClient().PostAsync("https://localhost:7033/api/ClientContoller/VtubeStudioData", content);

            var statusCode = response.EnsureSuccessStatusCode();

            Console.WriteLine("statusCode 200 OK");
        }
        catch (Exception ex)
        {
            Console.WriteLine("statusCode Error", ex);
        }
    }
}

