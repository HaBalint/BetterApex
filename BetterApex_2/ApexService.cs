using System;
using System.Collections.Generic;
using System.Text;

namespace BetterApex_2
{
    public class ApexService
    {
        private readonly ApexConnector _client;
        private readonly InitialParser _initParser;
        private readonly LiveRaceState _liveRaceState;
        public ApexService()
        {
            _client = new ApexConnector();
            _liveRaceState=new LiveRaceState();
            _initParser = new InitialParser(_liveRaceState);
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
