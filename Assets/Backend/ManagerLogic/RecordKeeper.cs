using UnityEngine;

public static class RecordKeeper
{
    public static MapFile mapFile = new MapFile();
    public static void NewSystemData(string s)
    {
        //Debug.Log("RecordKeeper: NewSystemData");

        // Prevent addition of duplicate systems.
        foreach (SolarSystem ss in mapFile.sysList)
        {
            if (ss.sysName == s) return;
        }

        // Add system data to back-end.
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mapFile.sysList.Add(new SolarSystem(s, mousePos.x, mousePos.y));
    }
    public static void NewSignatureData(SolarSystem ss, string sigStr)
    {
        //Debug.Log("RecordKeeper: NewSignatureData");

        // Store system position.
        var posX = ss.sceneX;
        var posY = ss.sceneY;

        // Check for existing signatures.
        foreach (CosmicSignature cs in ss.sigList)
        {
            if (cs.sigString.Substring(0, 7) == sigStr.Substring(0, 7))
            {
                // Update new signature position based on duplicate's position.
                posX = cs.sceneX;
                posY = cs.sceneY;

                // Remove the duplicate signature.
                ss.sigList.Remove(cs);
                break;
            }
        }

        // Add signature data to back-end.
        ss.sigList.Add(new CosmicSignature(sigStr, posX, posY, TextParser.GetSignatureType(sigStr), TextParser.GetSignatureColor(sigStr), TextParser.ParseSignatureName(sigStr)));
    }
    public static void RemoveSignature(CosmicSignature co)
    {
        //Debug.Log("RecordKeeper: RemoveSignature");

        // Iterate top-down to find and eliminate a specific signature by pointer.
        foreach (SolarSystem ss in mapFile.sysList)
        {
            foreach (CosmicSignature co2 in ss.sigList)
            {
                if (co == co2)
                {
                    ss.sigList.Remove(co);
                    return;
                }
            }
        }

    }
}
