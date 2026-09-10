using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BetterApex_2
{
    public class UpdateEntry
    {
        private readonly LiveRaceState _liveRaceState;

        public UpdateEntry(LiveRaceState racestate)
        {
            _liveRaceState = racestate;
        }

        public void Update(string rowID, string colID, string value)
        {
            TeamEntry? entry = _liveRaceState.GetEntry(rowID);                  //check if entry exists
            if (entry == null)
            {
                return;                                                         //if doesnt, do nothing
            }
            switch (colID)                                                      //switch case to determine the c"x" parameters meaning
            {
                case "c3":     //update drivers position         
                    if (int.TryParse(value, out int rank))
                    {
                        entry.rank = rank;
                    }
                    else
                    {
                        Debug.WriteLine($"Hibás paraméter konverzió: Entry ID:{rowID}   Paraméter: c3 (Pozíció)");
                    }
                    break;

                case "c5":
                    if (!int.TryParse(value,out int teamnum))
                    {
                        entry.teamNum = teamnum;
                    }
                    
                    break;

                case "c6":    //driver (or team) name
                    entry.name = value;
                    break;


                case "c10":     //update last lap time
                    if (TimeSpan.TryParse(value, out TimeSpan lastLap))
                    {
                        entry.lastLap = lastLap;
                    }
                    else
                    {
                        Debug.WriteLine($"Hibás paraméter konverzió itt: Entry ID: {rowID}   Paraméter: c10 (Last lap)");
                    }
                    break;



            }
        }
    }
}
