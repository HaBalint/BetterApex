using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Documents;

namespace BetterApex_2
{
    public class LiveRaceState
    {
        private readonly Dictionary<string, TeamEntry> _entries = new();

        public void CreateNewEntry(TeamEntry entryData)
        {
            if (_entries.ContainsKey(entryData.rowID)==true)
            {
                return;
            }

            _entries.Add(entryData.rowID, entryData);
        }
    }
}
