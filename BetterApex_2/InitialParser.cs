using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BetterApex_2
{
    public class InitialParser
    {
        public void Parse(string rawMessage)
        {
            int gridStart = rawMessage.IndexOf("grid||");   // van e benne egyáltalán grid info (ha nincs akkor -1 az értéke)
            int htmlStart=rawMessage.IndexOf("<tbody>");    // van e benne egyáltalán <tbody> (ha nincs akkor -1 az értéke)
            if (gridStart == -1 || htmlStart == -1)
            {
                return;
            }
            int gridEnd = rawMessage.IndexOf("</tbody>");
            int htmlLength = gridEnd+"</tbody>".Length-htmlStart;
            string gridHtml = rawMessage.Substring(htmlStart, htmlLength);
            Debug.WriteLine($"Grid Start: {gridStart}");
            Debug.WriteLine("Grid end: " + gridEnd);
            Debug.WriteLine("HTML Start: " + htmlStart);
            Debug.WriteLine("HTML Length: " + htmlLength);
            Debug.WriteLine("Grid HTML: " + gridHtml);
           
        }
    }
}
