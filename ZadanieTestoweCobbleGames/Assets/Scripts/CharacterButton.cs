using UnityEngine;
using TMPro;

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private TMP_Text characterNameText;

    private Character characterForButton;

    public void SetCharacterForButton(Character character)
    {
        characterForButton = character;
        characterNameText.text = character.CharacterName;
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
