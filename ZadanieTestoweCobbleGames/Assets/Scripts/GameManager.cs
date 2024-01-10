using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region GameManager Instance
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    #endregion

    [SerializeField] private CharactersManager charactersManager;
    [SerializeField] private UIManager uIManager;

    [SerializeField] private int numberOfCharacters = 3;

    private void Start()
    {
        charactersManager.CreateCharacter(numberOfCharacters);
        uIManager.CreateButton(numberOfCharacters);

        for (int i = 0; i < numberOfCharacters; i++)
        {
            Character character = charactersManager.CharactersList[i];
            CharacterButton characterButton = uIManager.CharacterButtonsList[i];
            characterButton.SetCharacterForButton(character);
        }
    }

    private void Update()
    {
        
    }

    public void TurnOffAllLeaders()
    {
        for (int i = 0; i < uIManager.CharacterButtonsList.Count; i++)
        {
            uIManager.CharacterButtonsList[i].TurnOffLeader();
        }
    }
}
