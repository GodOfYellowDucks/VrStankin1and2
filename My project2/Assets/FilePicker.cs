using System.IO;
using UnityEngine;
using SFB;

public class FilePicker : MonoBehaviour
{
    public PlayerData playerData;

    public void SaveData()
    {
        var path = StandaloneFileBrowser.SaveFilePanel("Save File", "", "playerData", "json");
        if (!string.IsNullOrEmpty(path))
        {
            string json = JsonUtility.ToJson(playerData);
            File.WriteAllText(path, json);
            Debug.Log("Data saved to " + path);
        }
    }

    public void LoadData()
    {
        var paths = StandaloneFileBrowser.OpenFilePanel("Open File", "", "json", false);
        if (paths.Length > 0 && !string.IsNullOrEmpty(paths[0]))
        {
            string path = paths[0];
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                playerData = JsonUtility.FromJson<PlayerData>(json);
                Debug.Log("Data loaded from " + path);
            }
            else
            {
                Debug.LogError("File not found: " + path);
            }
        }
    }
}
