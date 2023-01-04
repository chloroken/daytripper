using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TextAsset[] classText = new TextAsset[17];
    [SerializeField] Color[] classColor = new Color[17];
    [SerializeField] public LineRenderer lineRend;
    [SerializeField] GameObject systemPrefab;
    [SerializeField] GameObject signaturePrefab;
    [SerializeField] public GameObject infoPrefab;
    [SerializeField] public GameObject textPreview;

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