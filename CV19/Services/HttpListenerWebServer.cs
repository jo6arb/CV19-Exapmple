﻿using System;
using CV19.Services.Interfaces;

namespace CV19.Services
{
    internal class HttpListenerWebServer : IWebServerService
    {
        public bool Enabled { get; set; }
        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
