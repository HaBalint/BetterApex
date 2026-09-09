using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using HtmlAgilityPack;

namespace BetterApex_2
{
    public class InitialParser
    {
        public void Parse(string rawMessage)
        {
            int gridStart = rawMessage.IndexOf("grid||");   // van e benne egyáltalán grid info (ha nincs akkor -1 az értéke)
            int htmlStart=rawMessage.IndexOf("<tbody>");    // van e benne egyáltalán <tbody> (ha nincs akkor -1 az értéke)
            if (gridStart == -1 || htmlStart == -1)         //ha nincs grid info vagy nincs <tbody> akkor nem kell tovább menni
            {
                return;
            }
            int gridEnd = rawMessage.IndexOf("</tbody>");
            int htmlLength = gridEnd+"</tbody>".Length-htmlStart;
            
            Debug.WriteLine($"Grid Start: {gridStart}");
            Debug.WriteLine("Grid end: " + gridEnd);
            Debug.WriteLine("HTML Start: " + htmlStart);
            Debug.WriteLine("HTML Length: " + htmlLength);

            string gridHtml = rawMessage.Substring(htmlStart, htmlLength);

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(gridHtml);

            var rows = doc.DocumentNode.SelectNodes("//tr");

            Debug.WriteLine($"Rows found: {rows?.Count}");
            foreach (var row in rows)
            {
                string rowId = row.GetAttributeValue("data-id", "");

                if (rowId == "r0")
                {
                    continue;                           //greek mode (NOP)
                }

                var kartCell = row.SelectSingleNode($".//*[@data-id='{rowId}c5']");
                string kartNumber = kartCell?.InnerText ?? "";

                Debug.WriteLine($"Entry row: {rowId}, Kart: {kartNumber}");
            }

        }
    }
}
