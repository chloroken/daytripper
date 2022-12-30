using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextAsset[] classText = new TextAsset[17];
    [SerializeField] Color[] classColor = new Color[17];
    [SerializeField] public LineRenderer lineRend;
    [SerializeField] GameObject systemPrefab;
    [SerializeField] GameObject signaturePrefab;

    void Start()
    {
        Serializer.ReadData();
        WorldBuilder.BuildUnityScene(systemPrefab, signaturePrefab, classText, classColor);
    }

    void Update()
    {
        InputHandler.Listen(this);
    }
}