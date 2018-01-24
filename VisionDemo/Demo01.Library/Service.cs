using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.Storage;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
//using Microsoft.Cognitive.CustomVision.Prediction;

namespace Demo01
{
    public class Service
    {
        const string PredictionKey = "08eeaca3d815406abae0d22e7b407dda";
        const string PredictionUrl = "https://southcentralus.api.cognitive.microsoft.com/customvision/v1.1/Prediction/ba1ec5d2-29dd-4a83-8e74-21e86a5b3bcc/image?iterationId=aa90e9ea-c2ec-40b0-979b-0b2096535409";

        public async Task<CardsData> RequestAsync(StorageFile file)
        {
            HttpClient client = new HttpClient();

            //client.DefaultRequestHeaders.Add("Prediction-Key", PredictionKey);

            byte[] data = GetImageAsByteArray(file.Path);

            string responseContent;

            using (var content = new ByteArrayContent(data))
            {
                content.Headers.Add("Prediction-Key", PredictionKey);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                HttpResponseMessage response = await client.PostAsync(PredictionUrl, content);
                responseContent = response.Content.ReadAsStringAsync().Result;
            }

            var x = responseContent;

            return new CardsData();

            //return new Something { Cards = new[] { Cards.h1, Cards.h2 } };
        }

        static byte[] GetImageAsByteArray(string filePath)
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }
    }

    public enum Cards
    {
        h1 = 1,
        h2 = 2,
        h3 = 3,
        h4 = 4,
        h5 = 5,
        h6 = 6,
        h7 = 7,
        h8 = 8,
        h9 = 9,
        h10 = 10,
        h11 = 11,
        h12 = 12,
        h13 = 13
    }

    public class CardsData
    {
        public Cards[] Cards { get; set; }
    }
}
