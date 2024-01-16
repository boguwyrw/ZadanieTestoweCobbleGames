using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    private const string PART_NAME = "Player_";

    [SerializeField] private GameObject characterPrefab;

    private List<Character> charactersList = new List<Character>();
    private List<Character> charactersOrderList = new List<Character>();

    public List<Character> CharactersList { get { return charactersList; } }
    public List<Character> CharactersOrderList { get { return charactersOrderList; } }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void AddCharacterToOrder(bool isLeading, int index)
    {
        if (isLeading)
        {
            charactersOrderList.Add(charactersList[index]);
        }
    }

    public void CreateCharacter(int charactersNo)
    {
        for (int i = 0; i < charactersNo; i++)
        {
            Character characterClone = null;
            characterClone = Instantiate(characterPrefab, new Vector3(i, 0.0f, 0.0f), Quaternion.identity, transform).GetComponent<Character>();
            characterClone.CharacterName = PART_NAME + (i+1);
            charactersList.Add(characterClone);
        }
    }

    public void SetCharactersOrder()
    {
        int charactersLength = charactersList.Count;
        for (int i = 0; i < charactersLength; i++)
        {
            AddCharacterToOrder(isLeading: charactersList[i].IsLeading, i);
        }

        for (int j = 0; j < charactersLength; j++)
        {
            AddCharacterToOrder(isLeading: !charactersList[j].IsLeading, j);
        }

        for (int k = 0; k < charactersLength; k++)
        {
            Character character = charactersOrderList[k];
            character.SetIndex = k;
        }

        GameManager.Instance.CharactersWalkOrderList = charactersOrderList;
    }
}
