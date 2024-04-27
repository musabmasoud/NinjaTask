using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SnapchatService
    {
        private readonly HttpClient _httpClient;
        private readonly string _snapchatApiBaseUrl = "https://api.snapchat.com"; // Adjust base URL as per Snapchat's API documentation

        public SnapchatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> PushToCustomSegment(Users userSegment, string segmentName)
        {
            try
            {
                var payload = new
                {
                    name = userSegment.Name,
                    age = userSegment.Age,
                    gender = userSegment.Gender,
                    City = userSegment.City,
                    segment = segmentName
                };

                var jsonPayload = JsonSerializer.Serialize(payload);

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"{_snapchatApiBaseUrl}/custom-segments"),
                    Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json")
                };

                // Add authentication headers, if required by Snapchat's API

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return true; // Successfully pushed to Snapchat
                }
                else
                {
                    // Log or handle the error
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }
    }
}

