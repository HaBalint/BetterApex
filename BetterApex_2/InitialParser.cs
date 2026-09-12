using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using HtmlAgilityPack;

namespace BetterApex_2
{
    public class InitialParser
    {
        private readonly LiveRaceState _raceState;
        public void Parse(string rawMessage)
        {
            int gridStart = rawMessage.IndexOf("grid||");                       // van e benne egyáltalán grid info (ha nincs akkor -1 az értéke)
            int htmlStart=rawMessage.IndexOf("<tbody>");                        // van e benne egyáltalán <tbody> (ha nincs akkor -1 az értéke)
            int gridEnd = rawMessage.IndexOf("</tbody>");                       //grid vége index (ha nincs akkor -1 az értéke)
            if (gridStart == -1 || htmlStart == -1 || gridEnd == -1)            //ha nincs grid info vagy nincs <tbody> akkor nem kell tovább menni
            {
                return;
            }

            if (gridEnd == -1)                                                   //ha nincs </tbody> akkor nem kell tovább menni
            {
                return;
            }
            int htmlLength = gridEnd+"</tbody>".Length-htmlStart;
            //-------------------szarságok magamnak-------------------
            Debug.WriteLine($"Grid Start: {gridStart}");
            Debug.WriteLine("Grid end: " + gridEnd);
            Debug.WriteLine("HTML Start: " + htmlStart);
            Debug.WriteLine("HTML Length: " + htmlLength);
            //--------------------------------------------------------
            string gridHtml = rawMessage.Substring(htmlStart, htmlLength);

            HtmlDocument body_html = new HtmlDocument();                        //load gridhtml as html document
            body_html.LoadHtml(gridHtml);

            var rows = body_html.DocumentNode.SelectNodes("//tr");              //table rows keresés

            Debug.WriteLine($"Rows found: {rows?.Count}");


            foreach (var row in rows)
            {
                string rowId = row.GetAttributeValue("data-id", "");
                if (rowId == "r0")
                {
                    continue;                                                   //greek mode (NOP)
                }


                string rankString = GetCellValue(row, rowId, "c3");             //ha van adat, pakolja be egy TeamEntrybe
                string teamNumString = GetCellValue(row, rowId, "c5");          //
                string nameString = GetCellValue(row, rowId, "c6");             //                                             //
                TeamEntry entry = new TeamEntry();                              //
                entry.rank= int.TryParse(rankString, out int rank) ? rank : 0;  //
                entry.teamNum = int.TryParse(teamNumString, out int teamNum) ? teamNum : -1;  
                entry.name = nameString;                                        //
                entry.rowID = rowId;                                            //
                _raceState.CreateNewEntry(entry);                               
            }


        }
        private string GetCellValue(HtmlNode row, string rowId, string colId)   //cell value lekérdezése a row-ból a data-id alapján
        {
            var cell = row.SelectSingleNode($".//*[@data-id='{rowId}{colId}']");
            return cell?.InnerText ?? "";
        }

        public InitialParser(LiveRaceState raceState)
        {
            _raceState= raceState;
        }
    }
}
