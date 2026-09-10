using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;




/*                          Data header explanation
 *                          
 * <td data - id = "c1" data - type = "grp" data - pr = "6" ></ td >                                    (No clue)
    < td data - id = "c2" data - type = "sta" data - pr = "1" ></ td >                                  (State, possibly [OUT, PIT, stb])
    < td data - id = "c3" data - type = "rk" data - pr = "1" >                                          Rnk </ td >
    < td data - id = "c4" data - type = "nat" data - pr = "5" data - width = "6" >                      Nation </ td >
    < td data - id = "c5" data - type = "no" data - pr = "1" >                                          Kart </ td >
    < td data - id = "c6" data - type = "dr" data - pr = "1" data - width = "20" data - min = "16" >    Driver </ td >
    < td data - id = "c7" data - type = "s1" data - pr = "3" data - width = "9" data - min = "6" >      S1 </ td >
    < td data - id = "c8" data - type = "s2" data - pr = "3" data - width = "9" data - min = "6" >      S2 </ td >
    < td data - id = "c9" data - type = "s3" data - pr = "3" data - width = "9" data - min = "6" >      S3 </ td >
    < td data - id = "c10" data - type = "llp" data - pr = "2" data - width = "9" data - min = "7" >    Last lap </ td >
    < td data - id = "c11" data - type = "blp" data - pr = "1" data - width = "9" data - min = "7" >    Best lap </ td >
    < td data - id = "c12" data - type = "gap" data - pr = "4" data - width = "9" data - min = "7" >    Gap </ td >
    < td data - id = "c13" data - type = "tlp" data - pr = "5" data - width = "4" data - min = "4" >    Laps </ td >
    < td data - id = "c14" data - type = "otr" data - pr = "2" data - width = "7" data - min = "4" >    On track </ td >
    < td data - id = "c15" data - type = "pit" data - pr = "2" data - width = "5" data - min = "7" >    Pits </ td >

*/

namespace BetterApex_2
{
    public class TeamEntry
    {
        public string rowID { get; set; } = "";         //apex timing row ID (fix, does not change)
        public int internalKartId { get; set; }

        public int rank { get; set; }                   //position
        public int nation { get; set; }                 //nation
        public int teamNum { get; set; } = -1;          //kart number (during endurance race, its team number) default value -1, indicates missing data
        public string name { get; set; }                //driver or team name
        public TimeSpan s1 { get; set; }                //sector 1 time
        public TimeSpan s2 { get; set; }                //sector 2 time
        public TimeSpan s3 { get; set; }                //sector 3 time
        public TimeSpan lastLap { get; set; }           //last lap time
        public TimeSpan bestLap { get; set; }           //best lap
        public string gap { get; set; }                 //gap, because over 1 lap, it becames from 1:11.142 (time data) to "+1 lap", which is a string
        public int laps { get; set; }                   //total number of laps
        public TimeSpan onTrack { get; set; }           //time on track
        public int pits { get; set; }                   //number of pit stops
    }
}
