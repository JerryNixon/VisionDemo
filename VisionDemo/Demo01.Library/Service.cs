using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Demo01
{
    public class Service
    {
        public async Task<Something> RequestAsync(StorageFile file)
        {
            // Windows.Web.Http.HttpClient
            return new Something { Cards = new[] { Cards.h1, Cards.h2, Cards.h3, Cards.h12 } };
        }
    }

    public enum Cards : int { h1 = 1, h2 = 2, h3 = 3, h4 = 4, h5 = 5, h6 = 6, h7 = 7, h8 = 8, h9 = 9, h10 = 10, h11 = 11, h12 = 12, h13 = 13 }

    public class Something
    {
        public Cards[] Cards { get; set; }
    }
}
