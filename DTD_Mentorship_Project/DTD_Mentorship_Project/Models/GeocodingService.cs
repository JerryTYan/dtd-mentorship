using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project; // Namespace where your models are defined
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Geocoding;
using Geocoding.Google;



namespace DTD_Mentorship_Project.Models
{


    public class GeocodingService 
    {
        private readonly ILogger<GeocodingService> _logger;

        public GeocodingService(ILogger<GeocodingService> logger)
        {
            _logger = logger;
        }

        public class GoogleGeocodingResult
        {
            public List<Result> results { get; set; }

            public class Result
            {
                public List<AddressComponent> address_components { get; set; }

                public class AddressComponent
                {
                    public List<string> types { get; set; }
                    public string long_name { get; set; }
                    public string short_name { get; set; }
                }
            }
        }

        public async Task<List<string>> SuggestCitiesAndZips(string input)
        {
            // Call Google Geocoding API to get details based on the input
            var apiKey = "AIzaSyD1iZNxzv1FWSX9ZKyrGSOn6o0f5mG7IPk";
            var apiUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(input)}&key={apiKey}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                var geocodingResult = JsonSerializer.Deserialize<GoogleGeocodingResult>(response);

                // Extract city, state, and zip from the geocoding result
                var suggestions = geocodingResult?.results?.Select(result =>
                {
                    var addressComponents = result.address_components;
                    var city = addressComponents.FirstOrDefault(c => c.types.Contains("locality"))?.long_name;
                    var state = addressComponents.FirstOrDefault(c => c.types.Contains("administrative_area_level_1"))?.long_name;
                    var zip = addressComponents.FirstOrDefault(c => c.types.Contains("postal_code"))?.long_name;

                    return $"{city}, {state} {zip}";
                }).ToList();

                return suggestions;
            }
        }
    }


}
