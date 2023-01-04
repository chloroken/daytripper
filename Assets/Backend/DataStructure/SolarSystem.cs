using System.Collections.Generic;

[System.Serializable]
public class SolarSystem
{
    public string sysName;
    public float sceneX;
    public float sceneY;
    public List<CosmicSignature> sigList;
    
    public SolarSystem(string n, float x, float y)
    {
        sysName = n;
        sceneX = x;
        sceneY = y;
        sigList = new List<CosmicSignature>();
    }
}