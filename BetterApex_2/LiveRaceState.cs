using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Windows.Documents;

namespace BetterApex_2
{
    public class LiveRaceState
    {
        private readonly Dictionary<string, TeamEntry> _entries = new();    //for internal operations

        public void CreateNewEntry(TeamEntry entryData)                     //create new entry from the passed TeamEntry data
        {
            if (_entries.ContainsKey(entryData.rowID)==true)
            {
                return;
            }

            _entries.Add(entryData.rowID, entryData);
        }

        public TeamEntry? GetEntry(string rowID)                            //return the entry with the passed rowID
        {
            if (_entries.TryGetValue(rowID, out TeamEntry? entry))
            {
                return entry;
            }
            return null;
        }
    }
}
