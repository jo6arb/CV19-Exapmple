using System;
using System.Net;
using System.Threading.Tasks;

namespace CV19.Web
{
    public class WebServer
    {
        public event  EventHandler<RequestReceiverEventArgs> RequestReceived;
        /*private TcpListener _listener = new TcpListener(new IPEndPoint(IPAddress.Any, 8080));*/
        private HttpListener _Listener;
        private readonly int _port;
        private  bool _enabled;
        private readonly object _SyncRoot = new object();

        public int Port => _port;

        public  bool Enabled { get => _enabled; set {if(value) Start(); else Stop(); } }

        public WebServer(int port) => _port = port;

        public void Start()
        {
            if(_enabled) return;
            lock (_SyncRoot)
            {
                if(_enabled) return;
                _Listener = new HttpListener();
                _Listener.Prefixes.Add($"http://*:{_port}/");
                _Listener.Prefixes.Add($"http://+:{_port}/");
                _enabled = true;
            }
            ListenAsync();
        }

        public void Stop()
        {
            if (!_enabled) return;
            lock (_SyncRoot)
            {
                if (!_enabled) return;

                _Listener = null;
                _enabled = false;
            }
            
        }

        private async void ListenAsync()
        {
            var listener = _Listener;

            listener.Start();

            HttpListenerContext context = null;



            while (_enabled)
            {
                var getComContextTask = listener.GetContextAsync();
                if (context !=null)
                    ProcessRequestAsync(context);
                context = await getComContextTask.ConfigureAwait(false);
               }
               
            
            listener.Stop();

        }

        private async void ProcessRequestAsync(HttpListenerContext context)
        {
            await Task.Run(() => { RequestReceived?.Invoke(this, new RequestReceiverEventArgs(context)); });
        }
    }

    public class RequestReceiverEventArgs : EventArgs
    {
        public HttpListenerContext Context { get; }

        public RequestReceiverEventArgs(HttpListenerContext context) => Context = context;
    }
}
