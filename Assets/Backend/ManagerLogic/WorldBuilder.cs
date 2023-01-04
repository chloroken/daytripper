using UnityEngine;

public static class WorldBuilder
{
    public static void BuildUnityScene(GameObject sysPrefab, GameObject sigPrefab, TextAsset[] textAssets, Color[] textColor)
    {
        //Debug.Log("WorldBuilder: BuildUnityScene");

        // Iterate through MapFile, building scene as we go.
        foreach (SolarSystem ss in RecordKeeper.mapFile.sysList)
        {
            GameObject newSys = InstantiateSolarSystem(ss, sysPrefab, textAssets, textColor);
            foreach (CosmicSignature cs in ss.sigList)
            {
                InstantiateCosmicSignature(newSys, cs, sigPrefab);
            }
        }
    }

    static GameObject InstantiateSolarSystem(SolarSystem ss, GameObject sysPrefab,  TextAsset[] textAssets, Color[] textColor)
    {
        //Debug.Log("WorldBuilder: InstantiateSolarSystem");

        // Create a system GameObject and supply it with some initial data.
        var systemPosition = new Vector3(ss.sceneX, ss.sceneY, 0f);
        var newSystem = Object.Instantiate(sysPrefab, systemPosition, Quaternion.identity);
        var sysObj = newSystem.GetComponent<SystemObject>();
        var sysClass = TextParser.FindSystemClass(ss.sysName, textAssets);
        //Debug.Log(sysClass);
        sysObj.sprRend.color = textColor[sysClass];
        sysObj.sysText = (ss.sysName + "\n") + TextParser.GenerateSystemLabel(sysClass);
        sysObj.sysData = ss;
        return(newSystem);
    }
    
    static void InstantiateCosmicSignature(GameObject parSys, CosmicSignature cs, GameObject sigPrefab)
    {
        //Debug.Log("WorldBuilder: InstantiateCosmicSignature");

        // Create a signature GameObject and supply it with some initial data.
        var nudge = new Vector3(Random.Range(-0.001f, 0.001f), Random.Range(-0.001f, 0.001f), 0f);
        var signaturePosition = new Vector3(cs.sceneX, cs.sceneY, 0f) + nudge;
        var newSignature = Object.Instantiate(sigPrefab, signaturePosition, Quaternion.identity);
        newSignature.transform.SetParent(parSys.transform);
        newSignature.GetComponent<SignatureObject>().sigData = cs;
        newSignature.GetComponent<SignatureObject>().parentSystemObject = parSys;
        newSignature.GetComponent<SignatureObject>().signatureType = cs.sigType;
        newSignature.GetComponent<SignatureObject>().sigText = cs.sigString.Substring(0, 3);
    }
}
