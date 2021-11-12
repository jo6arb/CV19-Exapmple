using System.Net;

namespace CV19.Web
{
    public class WebServer
    {
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
                _Listener.Prefixes.Add($"http://*:{_port}");
                _Listener.Prefixes.Add($"http://+:{_port}");
                _enabled = true;
            }
            Listen();
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

        private void Listen() { }
    }
}
