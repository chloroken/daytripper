using UnityEngine;
using TMPro;

public class SignatureObject : MonoBehaviour
{
    [SerializeField] LineRenderer lineRend;
    SpriteRenderer sprRend;
    public Sprite[] signatureSprites = new Sprite[7];
    Color iconColor = new Color(0,0,0);
    public GameObject linkObj = null;
    public GameObject parentSystemObject;
    public CosmicSignature sigData;
    public Component sigLabel;
    public string sigText;
    public int signatureType = 0;
    bool reachDest = false;

    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        // Match front-end with back-end.
        UpdateSpriteAndText();
        UpdateLinkObject();

        // Follow parent system around (gravity).
        ChaseParentSystem(0.6f);

        // Draw wormhole link lines.
        if (linkObj != null)
        {
            var vectAdjust = new Vector3(0f, 0f, 10f);
            lineRend.SetPosition(0, transform.position + vectAdjust);
            lineRend.SetPosition(1, linkObj.transform.position + vectAdjust);
        }
    }

    void UpdateSpriteAndText()
    {
        // Match front-end sprite/label to back-end data.
        if (signatureType != 0) sprRend.sprite = signatureSprites[signatureType];
        if (sprRend.color != iconColor)
        {
            ColorUtility.TryParseHtmlString(sigData.iconColor, out iconColor);
            sprRend.color = iconColor;
        }
        var t = sigLabel.GetComponent<TextMeshPro>();
        if (t.text != sigText) t.text = sigText;

    }

    void UpdateLinkObject()
    {
        // Link GameObject based on back-end wormhole link data.
        if ((linkObj == null) && (sigData.linkString != ""))
        {
            GameObject[] sigs = GameObject.FindGameObjectsWithTag("Signature");
            foreach (GameObject go in sigs)
            {
                if (sigData.linkString == go.GetComponent<SignatureObject>().sigData.sigString)
                {
                    linkObj = go;
                    break;
                }
            }
        }
    }

    void ChaseParentSystem(float minDist)
    {
        // Follow parent system around, with gradual 'gravity' for fun.
        if (parentSystemObject != null)
        {
            var dist = Vector3.Distance(transform.position, parentSystemObject.transform.position);
            if ((dist > minDist) && (!reachDest))
            {
                transform.position = Vector3.MoveTowards(transform.position, parentSystemObject.transform.position, dist * Time.deltaTime);
            }
            if ((dist <= minDist) && (!reachDest)) reachDest = true;
            if ((dist > minDist * 1.25f) && (reachDest)) reachDest = false;

        }
    }
}
