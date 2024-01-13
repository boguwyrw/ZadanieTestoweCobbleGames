using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterButton : MonoBehaviour
{
    private Character characterForButton;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetCharacterForButton(Character character)
    {
        characterForButton = character;
    }

    public void SetLeader()
    {
        GameManager.Instance.TurnOffAllLeaders();
        characterForButton.IsLeading = true;
        characterForButton.IsPathCheck = true;
    }

    public void TurnOffLeader()
    {
        characterForButton.IsLeading = false;
    }
}
