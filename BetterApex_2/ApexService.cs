using System;
using System.Collections.Generic;
using System.Text;

namespace BetterApex_2
{
    public class ApexService
    {
        private readonly ApexWebSocketClient _client;
        private readonly InitialParser _initParser;

        public ApexService()
        {
            _client = new ApexWebSocketClient();
            _initParser = new InitialParser();
            _client.MessageReceived += OnMessageReceived;

        }

        private void OnMessageReceived(string message)
        {
            _initParser.Parse(message);
        }

        public async Task StartAsync()
        {
            await _client.ConnectAsync();
        }

    }
}
