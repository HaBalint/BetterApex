using System;
using System.Collections.Generic;
using System.Text;

namespace BetterApex_2
{
    public class TeamEntry
    {
        public string rowID { get; set; } = "";         //apex timing row ID (fix, does not change)
        public int internalKartId { get; set; }

        public int rank { get; set; }                   //position
        public int nation { get; set; }                 //nation
        public int teamNum { get; set; } = -1;          //kart number (during endurance race, its team number) default value -1 ó, indicates missing data
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
