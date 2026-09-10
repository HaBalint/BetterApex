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
                //case "c1":    //    NO IDEA
                //    entry.name = value;
                //    break;

                //case "c2":    //    NO FUCKING IDEA EITHER
                //    entry.name = value;
                //    break;

                case "c3":     //   update drivers position         
                    if (int.TryParse(value, out int rank))
                    {
                        entry.rank = rank;
                    }
                    else
                    {
                        Debug.WriteLine($"Hibás paraméter konverzió: Entry ID:{rowID}   Paraméter: c3 (Pozíció)");
                    }
                    break;

                //case "c4":    //    NATION
                    //if (int.TryParse(value, out int teamnum))
                    //{
                    //    entry.teamNum = teamnum;
                    //}
                    //break;

                case "c5":    //    TEAM NUMBER
                    if (int.TryParse(value,out int teamnum))
                    {
                        entry.teamNum = teamnum;
                    }
                    break;

                case "c6":    //    TEAM NAME
                    entry.name = value;
                    break;

           //     case "c7":    //    SECTOR 1 TIME
           //        entry.name = value;
           //     break;

           //     case "c8":    //    SECTOR 2 TIME
           //         entry.name = value;
           //         break;

            //    case "c9":    //   SECTOR 3 TIME
            //        entry.name = value;
            //        break;

                case "c10":     //  LAST LAP
                    if (TimeSpan.TryParse(value, out TimeSpan lastLap))         // !!!check if it convers time normally, C# be doin some retard shit sometimes!!!
                    {
                        entry.lastLap = lastLap;
                    }
                    else
                    {
                        Debug.WriteLine($"Hibás paraméter konverzió itt: Entry ID: {rowID}   Paraméter: c10 (Last lap)");
                    }
                    break;

               //case "c11":    //   BEST LAP
               //    entry.name = value;
               //    break;

               //case "c12":    //   GAP
               //    entry.name = value;
               //    break;

               //case "c13":    //    LAPS
               //    entry.name = value;
               //    break;

               //case "c14":    //    ON TRACK TIME
               //    entry.name = value;
               //    break;

               //case "c15":    //    PITS
               //    entry.name = value;
               //    break;


            }
        }
    }
}
