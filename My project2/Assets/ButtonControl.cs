using System;
using System.IO;
using UnityEngine;

[Serializable]
public class ButtonData
{
    public bool isOn;
    public float currentSpindleSpeed;
    public Vector3 knopkaRotation;
}

public class ButtonDataController : MonoBehaviour

{
    public ButtonController buttonController;
    private string dataPath;

    private void Start()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "buttonData.json");
    }

    public void SaveData()
    {
        ButtonData data = new ButtonData
        {
            isOn = buttonController.isOn,
            currentSpindleSpeed = buttonController.currentSpindleSpeed,
            knopkaRotation = buttonController.knopka.transform.localRotation.eulerAngles // Сохранение как Euler angles
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, json);
        Debug.Log("Data saved to " + dataPath);
    }

    public void LoadData()
    {
        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            ButtonData data = JsonUtility.FromJson<ButtonData>(json);

            buttonController.isOn = data.isOn;
            buttonController.currentSpindleSpeed = data.currentSpindleSpeed;
            buttonController.knopka.transform.localRotation = Quaternion.Euler(data.knopkaRotation); // Преобразование обратно в Quaternion
            Debug.Log("Data loaded from " + dataPath);
        }
        else
        {
            Debug.LogError("Save file not found in " + dataPath);
        }
    }
}
