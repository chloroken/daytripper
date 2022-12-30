using UnityEngine.SceneManagement;
using UnityEngine;

public static class InputHandler
{
    static GameObject movingObject = null;
    public static GameObject linkingObject = null;
    public static bool linkingCurrently = false;

    public static void Listen(GameManager gameManager)
    {
        // Object addition/removal.
        if (Input.GetKeyDown(KeyCode.V)) CommandPasteData(gameManager);
        if (Input.GetMouseButton(1)) CommandRemoveObject();

        // Wormhole linking.
        if (Input.GetMouseButtonDown(2)) CommandLinkWormholes();
        if (Input.GetMouseButtonUp(2)) CommandCompleteLink();
        if (Input.GetMouseButtonDown(2)) CommandClearLink(GetObjectUnderCursor());
        UpdateLinkPreviewLine(gameManager);

        // Object dragging.
        if (Input.GetMouseButtonDown(0)) CommandStartDrag();
        if (Input.GetMouseButton(0)) CommandDragObject();
        else CommandStopDrag();
    }

    static void CommandPasteData(GameManager gameManager)
    {
        //Debug.Log("InputHandler: CommandPasteData");

        // Use TextParser to determine what to do (system, signature, nothing) based on our clipboard data.
        string clipboard = GUIUtility.systemCopyBuffer;
        if (TextParser.StringIsSystem(clipboard)) RecordKeeper.NewSystemData(TextParser.ParseSystemName(clipboard));
        else if (TextParser.StringIsSignature(clipboard))
        {
            GameObject hoverObject = GetObjectUnderCursor();
            if (hoverObject == null) return;
            if (hoverObject.tag != "System") return;

            foreach (string sigStr in TextParser.SplitSignatureStrings(clipboard))
            {
                RecordKeeper.NewSignatureData(hoverObject.GetComponent<SystemObject>().sysData, sigStr);
            }
        }

        Serializer.SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    static void CommandRemoveObject()
    {
        //Debug.Log("InputHandler: CommandRemoveObject");

        // Remove systems and/or signatures from back-end.
        var checkObj = GetObjectUnderCursor();
        if (checkObj == null) return;
        if (checkObj.tag == "System") RecordKeeper.mapFile.sysList.Remove(checkObj.GetComponent<SystemObject>().sysData);
        else if (checkObj.tag == "Signature")
        {
            CommandClearLink(checkObj);
            RecordKeeper.RemoveSignature(checkObj.GetComponent<SignatureObject>().sigData); 
        }
        
        Serializer.SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    static GameObject GetObjectUnderCursor()
    {
        //Debug.Log("InputHandler: GetObjectUnderCursor");

        // Cast a ray from mouse in search of GameObjects.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.transform != null) return(hit.transform.gameObject);
        else return(null);
    }

    static void CommandLinkWormholes()
    {
        //Debug.Log("InputHandler: CommandLinkWormholes");

        // Perform checks to ensure this is a valid command.
        if (linkingCurrently) return;
        var mouseObj = GetObjectUnderCursor();
        if (mouseObj == null) return;
        if (mouseObj.tag != "Signature") return;
        if (mouseObj.GetComponent<SignatureObject>().signatureType != 1) return;
        if (mouseObj.GetComponent<SignatureObject>().linkObj != null) return;

        linkingCurrently = true;
        linkingObject = GetObjectUnderCursor();
    }

    static void CommandCompleteLink()
    {
        //Debug.Log("InputHandler: CommandCompleteLink");

        // Finish linking two wormhole signatures.
        if (linkingObject == null) return;
        var mouseObj = GetObjectUnderCursor();
        if (mouseObj != null)
        {
            if (mouseObj.tag == "Signature")
            {
                linkingObject.GetComponent<SignatureObject>().linkObj = mouseObj;
                linkingObject.GetComponent<SignatureObject>().sigData.linkString = mouseObj.GetComponent<SignatureObject>().sigData.sigString;
                mouseObj.GetComponent<SignatureObject>().linkObj = linkingObject;
                mouseObj.GetComponent<SignatureObject>().sigData.linkString = linkingObject.GetComponent<SignatureObject>().sigData.sigString;
            }
        }

        // Clear flags
        linkingCurrently = false;
        linkingObject = null;

        Serializer.SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void CommandClearLink(GameObject go)
    {
        //Debug.Log("InputHandler: CommandClearLink");

        // Make sure user is hovering a Signature Object.
        if (go == null) return;
        if (go.tag != "Signature") return;

        // Validate signature type, and that a link exists.
        var sigObj = go.GetComponent<SignatureObject>();
        if (sigObj.sigData.sigType != 1) return;
        if (sigObj.sigData.linkString == "") return;

        // Remove both ends of connection in backend.
        sigObj.sigData.linkString = "";
        sigObj.linkObj.GetComponent<SignatureObject>().sigData.linkString = "";
        sigObj.linkObj.GetComponent<SignatureObject>().linkObj = null;
        sigObj.linkObj = null;

        Serializer.SaveData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
 
    static void UpdateLinkPreviewLine(GameManager gm)
    {
        //Debug.Log("InputHandler: UpdateLinkPreviewLine");

        // Draw a temporary line to help visual wormhole-linking process.
        if (InputHandler.linkingCurrently)
        {
            gm.lineRend.enabled = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gm.lineRend.SetPosition(0, InputHandler.linkingObject.transform.position);
            gm.lineRend.SetPosition(1, mousePos);
        }
        else gm.lineRend.enabled = false;
    }
 
    static void CommandStartDrag()
    {
        //Debug.Log("InputHandler: CommandStartDrag");

        // Indicate user wants to drag a GameObject.
        if (movingObject == null)
        {
            var mouseObj = GetObjectUnderCursor();
            if (mouseObj != null) movingObject = mouseObj;
        }
    }

    static void CommandDragObject()
    {
        //Debug.Log("InputHandler: CommandDragObject");

        // Actually drag previously-selected GameObject.
        if (movingObject != null)
        {
            var newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movingObject.transform.position = new Vector3(newPos.x, newPos.y, 0.0f);
        }
    }

    static void CommandStopDrag()
    {
        //Debug.Log("InputHandler: CommandStopDrag");
        
        // Stop dragging GameObjects.
        if (movingObject != null)
        {
            movingObject = null;
            Serializer.SaveData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
