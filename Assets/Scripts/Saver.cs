using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<CellData> cells;
    public int score;
}

[System.Serializable]
public class CellData
{
    public Vector2Int position;
    public int value;
}

public class Saver : MonoBehaviour
{
    public void SaveGame(List<Cell> cells, int score)
    {
        SaveData saveData = new SaveData();
        saveData.cells = new List<CellData>();

        foreach (var cell in cells)
        {
            saveData.cells.Add(new CellData { position = cell.Position, value = cell.Value });
        }

        saveData.score = score;

        string path = Path.Combine(Application.persistentDataPath, "save.dat");
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, saveData);
        }

        Debug.Log("Game saved");
    }

    public SaveData LoadGame()
    {
        string path = Path.Combine(Application.persistentDataPath, "save.dat");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return formatter.Deserialize(stream) as SaveData;
            }
        }

        Debug.LogError("Save file not found");
        return null;
    }
}
