using System;
using System.Collections.Generic;
using System.Text;

namespace CV19.Services.Interfaces
{
    internal interface IWebServerService
    {
        bool Enabled { get; set; }
        void Start();

        void Stop();
    }
}
