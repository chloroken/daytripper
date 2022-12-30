[System.Serializable]
public class CosmicSignature
{
    public string sigString;
    public string linkString;
    public float sceneX;
    public float sceneY;
    public int sigType;
    public string iconColor;
    
    public CosmicSignature(string s, float x, float y, int t, string c)
    {
        sigString = s;
        sceneX = x;
        sceneY = y;
        sigType = t;
        iconColor = c;
        linkString = "";
    }
}