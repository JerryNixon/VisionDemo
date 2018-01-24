using System.IO;
using System.Linq;
using System.Text;
using Windows.Storage;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Demo01.Models;
using Demo01.Json;

namespace Demo01
{
    public class Service
    {
        private CognitiveHelper _helper;

        public Service()
        {
            _helper = new CognitiveHelper(Settings.PredictionKey, Settings.Endpoint);
        }

        public async Task<PredictionResult> PredictAsync(StorageFile file)
        {
            var bytes = await _helper.ToByteArrayAsync(file);

            var json = await _helper.PostToServiceAsync(bytes);

            var root = JsonConvert.DeserializeObject<CognitiveRoot>(json);

            var result = new PredictionResult(root.Predictions.Select(x => x));

            return result;
        }
    }
}
