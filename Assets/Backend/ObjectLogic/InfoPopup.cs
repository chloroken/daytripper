using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPopup : MonoBehaviour
{
    public string sigCode;
    public string sigName;
    public Vector3 startPos;
    [SerializeField] TextMeshPro tmp;
    //[SerializeField] float breakDist = 1.0f;

    void Update()
    {
        var infoString = sigName;//sigCode + "\n" + sigName;
        if (tmp.text != infoString) tmp.text = infoString;

        if (Input.GetMouseButtonDown(1)) Destroy(gameObject);
    }
}