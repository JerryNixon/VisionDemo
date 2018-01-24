using System;
using System.Net.Http;
using Windows.Storage;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Windows.Storage.Streams;

namespace Demo01
{
    public class CognitiveHelper
    {
        private string _predictionKey;
        private string _predictionUrl;

        public CognitiveHelper(string predictionKey, string predictionUrl)
        {
            _predictionKey = predictionKey;
            _predictionUrl = predictionUrl;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Prediction-Key", _predictionKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public async Task<string> PostToServiceAsync(byte[] bytes)
        {
            var client = CreateClient();

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                var response = await client.PostAsync(_predictionUrl, content);
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<byte[]> ToByteArrayAsync(StorageFile file)
        {
            using (var stream = await file.OpenReadAsync())
            {
                using (var reader = new DataReader(stream.GetInputStreamAt(0)))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    var Bytes = new byte[stream.Size];
                    reader.ReadBytes(Bytes);
                    return Bytes;
                }
            }
        }
    }

}
