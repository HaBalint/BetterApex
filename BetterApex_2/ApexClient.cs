using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Websocket.Client;

namespace BetterApex_2
{
    public class ApexWebSocketClient
    {
        private readonly Uri _serverUri;
        private WebsocketClient _client;
        public event Action<string>? MessageReceived;

        public ApexWebSocketClient()
        {
            _serverUri = new Uri("wss://live-data.apex-timing.com:8533/");
        }

        public async Task ConnectAsync()
        {
            _client = new WebsocketClient(_serverUri);

            _client.ReconnectionHappened.Subscribe(info =>
            {
                Debug.WriteLine($"----------------------------------------------------------------------- WS connected: {info.Type} -----------------------------------------------------------------------");
            });

            _client.DisconnectionHappened.Subscribe(info =>
            {
                Debug.WriteLine($"----------------------------------------------------------------------- WS disconnected: {info.Type} -----------------------------------------------------------------------");
            });

            //_client.MessageReceived.Subscribe(msg =>
          //  {
          //      Debug.WriteLine(msg.Text);
          //  });

            _client.MessageReceived.Subscribe(msg =>
            {
                MessageReceived?.Invoke(msg.Text);
            });

            await _client.Start();

          
        }
    
        }
}