using System.Linq;
using Windows.Storage;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Demo01.Models;
using Demo01.Json;
using System.Collections.Generic;

namespace Demo01
{
    public class Service
    {
        public async Task<IEnumerable<CardInfo>> PredictAsync(StorageFile file)
        {
            var key = Settings.PredictionKey;
            var url = Settings.Endpoint;
            var cogs = new CognitiveHelper(key, url);

            var bytes = await cogs.ToByteArrayAsync(file);
            var json = await cogs.PostToServiceAsync(bytes);
            var root = JsonConvert.DeserializeObject<CognitiveRoot>(json);

            var cards = root.Predictions
                .Select(x => new CardInfo(x))
                .Where(x => x.Tag.IsCardTag());
            return cards;
        }
    }
}
