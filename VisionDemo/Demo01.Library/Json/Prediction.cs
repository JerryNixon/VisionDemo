using Newtonsoft.Json;

namespace Demo01.Json
{
    public partial class Prediction
    {
        [JsonProperty("TagId")]
        public string TagId { get; set; }

        [JsonProperty("Tag")]
        public string Tag { get; set; }

        [JsonProperty("Probability")]
        public double Probability { get; set; }
    }
}
