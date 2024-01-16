using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    private string filePath = "";
    private BinaryFormatter binaryFormatter;

    private void Start()
    {
        filePath = Application.dataPath + @"\Saves\progress.txt";
        binaryFormatter = new BinaryFormatter();
    }

    public async void SaveGameProgress(Character character)
    {
        FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);

        CharacterData characterData = new CharacterData(character);

        await Task.Run(() => binaryFormatter.Serialize(fileStream, characterData));

        fileStream.Close();
    }

    public async void LoadGameProgress(Character character)
    {
        if (File.Exists(filePath))
        {
            FileStream fileStream = new FileStream(filePath, FileMode.Open);

            CharacterData characterData = await Task.Run(() => binaryFormatter.Deserialize(fileStream) as CharacterData);

            character.transform.position = new Vector3(characterData.CharacterPosition.CoordX, 0.0f, characterData.CharacterPosition.CoordZ);

            fileStream.Close();
        }
    }
}
