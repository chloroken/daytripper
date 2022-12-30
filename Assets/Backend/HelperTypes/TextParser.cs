using System.Collections.Generic;
using UnityEngine;

public static class TextParser
{
    public static List<string> SplitSignatureStrings(string clipboard)
    {
        //Debug.Log("TextParser: SplitSignatureStrings");

        // Split clipboard up until a list of individual signatures.
        var splitList = new List<string>(clipboard.Split('\n'));
        splitList.RemoveAll(CosmicAnomaly);
        return(splitList);
    }
    
    static bool CosmicAnomaly(string s)
    {
        //Debug.Log("TextParser: CosmicAnomaly");

        // A predicate for the RemoveAll method in SplitSignatureStrings().
        if (s[15] == 'A') return(true);
        return(false);
    }

    public static int GetSignatureType(string sig)
    {
        //Debug.Log("TextParser: GetSignatureType");

        // Search signature strings for keywords, return site type int identifier.
        if (sig.Contains("Wormhole")) return(1);
        if (sig.Contains("Data Site")) return(2);
        if (sig.Contains("Relic Site")) return(3);
        if (sig.Contains("Combat Site")) return(4);
        if (sig.Contains("Ore Site")) return(5);
        if (sig.Contains("Gas Site")) return(6);
        return(0);
    }
    
    public static string GetSignatureColor(string sig)
    {
        //Debug.Log("TextParser: GetSignatureStatus");

        // Search signature string to determine "true" status color (combat/relic, etc).
        if (sig.Contains("Wormhole")) return("magenta");
        if (sig.Contains("Reservoir")) return("yellow");
        if (sig.Contains("Deposit")) return("cyan");
        if ((sig.Contains("Ruined")) || (sig.Contains("Central"))) return("green");
        if ((sig.Contains("Combat")) || (sig.Contains("Perimeter")) || (sig.Contains("Frontier")) || (sig.Contains("Core"))) return("red");
        return("black");
    }

    public static int FindSystemClass(string n, TextAsset[] t)
    {
        //Debug.Log("TextParser: FindSystemClass");

        // Search through TextAsset lists of systems which are split by class.
        for (var i = 0; i < t.Length; i ++)
        {
            if (t[i].text.Contains(n)) return(i);
        }
        return(0);
    }

    public static bool StringIsSystem(string s)
    {  
        //Debug.Log("TextParser: StringIsSystem");

        // Copying in-game system name links generates HTML, so check for '<'.
        if ((s[0]) == '<') return(true);
        return(false);
    }

    public static bool StringIsSignature(string s)
    {
        //Debug.Log("TextParser: StringIsSignature");

        // Copying signatures & anomalies will always begin with 'XYZ-123'.
        if ((s[3]) == '-') return(true);
        return(false);
    }

    public static string ParseSystemName(string s)
    {
        //Debug.Log("TextParser: ParseSystemName");

        // Crawl through the string, looking for start & end of system name.
        var recordString = false;
        var sysName = "";
        foreach (char c in s)
        {
            if (recordString)
            {
                if (c == '<') break;
                else sysName += c;
            }
            if (c == '>') recordString = true;
        }
        return(sysName);
    }

    public static string GenerateSystemLabel(int c)
    {
        //Debug.Log("TextParser: GenerateSystemLabel");
        
        // Generate supplemental text for GameObject label.
        if (c < 6) return("C" + (c + 1));
        else if (c == 6) return("C12");
        else if (c < 14) return("C" + (c + 6));
        else if (c == 13) return("Pochven");
        else if (c == 14) return("Nullsec");
        else if (c == 15) return("Lowsec");
        else return("Highsec");
    }
}