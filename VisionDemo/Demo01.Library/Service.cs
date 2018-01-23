﻿using System;
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
            return new Something { Cards = new[] { Cards.h1, Cards.h2 } };
        }
    }

    public enum Cards { h1, h2, h3 }

    public class Something
    {
        public Cards[] Cards { get; set; }
    }
}