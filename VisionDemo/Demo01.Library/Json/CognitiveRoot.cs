using System;
using Newtonsoft.Json;

namespace Demo01.Json
{
    public partial class CognitiveRoot
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Project")]
        public string Project { get; set; }

        [JsonProperty("Iteration")]
        public string Iteration { get; set; }

        [JsonProperty("Created")]
        public DateTime Created { get; set; }

        [JsonProperty("Predictions")]
        public Prediction[] Predictions { get; set; }
    }
}
