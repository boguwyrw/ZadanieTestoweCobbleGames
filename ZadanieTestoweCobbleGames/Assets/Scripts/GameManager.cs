using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharactersManager charactersManager;
    [SerializeField] private UIManager uIManager;

    [SerializeField] private int numberOfCharacters = 3;

    private void Start()
    {
        charactersManager.CreateCharacter(numberOfCharacters);
        uIManager.CreateButton(numberOfCharacters);
    }

    private void Update()
    {
        
    }
}
