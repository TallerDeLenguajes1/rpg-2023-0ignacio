using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiRickAndMorty
{
    public class ApiRyM
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("air_date")]
        public string Air_date { get; set; }

        [JsonPropertyName("episode")]
        public string Episode { get; set; }

        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
    }
}