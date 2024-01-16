using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;

    [SerializeField] private Transform content;

    private List<CharacterButton> characterButtonsList = new List<CharacterButton>();

    public List<CharacterButton> CharacterButtonsList { get { return characterButtonsList; } }

    public void CreateButton(int characters)
    {
        for (int i = 0; i < characters; i++)
        {
            CharacterButton buttonClone = null;
            buttonClone = Instantiate(buttonPrefab, content).GetComponent<CharacterButton>();
            characterButtonsList.Add(buttonClone);
        }
        
    }
}
