using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private string filePath = "";

    private void Start()
    {
        filePath = Application.dataPath + @"\Saves\progress.txt";       
    }

    private void Update()
    {
        
    }

    public async void SaveGameProgress(Character character)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);

        CharacterData characterData = new CharacterData(character);

        await Task.Run(() => binaryFormatter.Serialize(fileStream, characterData));

        fileStream.Close();
    }

    public async void LoadGameProgress(Character character)
    {
        if (File.Exists(filePath))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            CharacterData characterData = await Task.Run(() => binaryFormatter.Deserialize(fileStream) as CharacterData);

            character.transform.position = new Vector3(characterData.CharacterPosition[0], 0.0f, characterData.CharacterPosition[1]);

            fileStream.Close();
        }
    }
}
