using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;

    private List<Character> charactersList = new List<Character>();

    public List<Character> CharactersList { get { return charactersList; } }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void CreateCharacter(int charactersNo)
    {
        for (int i = 0; i < charactersNo; i++)
        {
            Character characterClone = null;
            characterClone = Instantiate(characterPrefab, new Vector3(i, 0.0f, 0.0f), Quaternion.identity, transform).GetComponent<Character>();
            charactersList.Add(characterClone);
        }
    }
}
