using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Serializer
{
    public static string savePath = "map.save";

    public static void ReadData()
    {
        //Debug.Log("Serializer: ReadData");

        // Use a binary formatter to retrieve a previously-serialized MapFile.
        if (File.Exists(savePath)) using (Stream stream = File.Open(savePath, FileMode.Open))
        {
            RecordKeeper.mapFile = (MapFile) new BinaryFormatter().Deserialize (stream);
        }
    }

    public static void SaveData()
    {
        //Debug.Log("Serializer: SaveData");

        // Iterate Unity GameObjects, updating MapFile data.
        GameObject[] sysPrefabs = GameObject.FindGameObjectsWithTag("System");
        foreach (GameObject go in sysPrefabs)
        {
            var sysObj = go.GetComponent<SystemObject>();
            sysObj.sysData.sceneX = go.transform.position.x;
            sysObj.sysData.sceneY = go.transform.position.y;
        }
        GameObject[] sigPrefabs = GameObject.FindGameObjectsWithTag("Signature");
        foreach (GameObject go in sigPrefabs)
        {
            var sigObj = go.GetComponent<SignatureObject>();
            sigObj.sigData.sceneX = go.transform.position.x;
            sigObj.sigData.sceneY = go.transform.position.y;
        }

        // Commit MapFile to disk.
        FileStream fs = new FileStream(savePath, FileMode.Create);
        new BinaryFormatter().Serialize(fs, RecordKeeper.mapFile);
        fs.Close();
    }
}