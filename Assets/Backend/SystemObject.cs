using UnityEngine;
using TMPro;

public class SystemObject : MonoBehaviour
{
    public SolarSystem sysData;
    public SpriteRenderer sprRend;
    public Component sysLabel;
    public string sysText;

    void Update()
    {
        // Update label if it doesn't match back-end.
        var t = sysLabel.GetComponent<TextMeshPro>();
        if (t.text != sysText) t.text = sysText;
    }
}