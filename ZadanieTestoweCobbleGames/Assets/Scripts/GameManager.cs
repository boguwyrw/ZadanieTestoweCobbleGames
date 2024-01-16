using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    #region Unity Editor Settings
    [Header("Unity Editor")]
    [SerializeField] private GameObject endPathNodeInfoGO;

    [SerializeField] private TMP_Text gCostText;
    [SerializeField] private TMP_Text hCostText;
    [SerializeField] private TMP_Text fCostText;
    #endregion

    [Header("Game")]
    [SerializeField] private CharactersManager charactersManager;
    [SerializeField] private UIManager uIManager;
    [SerializeField] private AStarPathfinding aStarPathfinding;
    [SerializeField] private SaveLoadSystem saveLoadSystem;

    [SerializeField] private int numberOfCharacters = 3;

    public bool CanStartMove { get; set; } = false;

    public List<Vector3> CharacterPathList { get; set; }
    public List<Character> CharactersWalkOrderList { get; set; }

    private void Start()
    {
        endPathNodeInfoGO.SetActive(false);

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
        RestartGame();

        SaveLoadGameProgress();

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!endPathNodeInfoGO.activeSelf)
            {
                endPathNodeInfoGO.SetActive(true);
            }
        }
#endif
    }

    private void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private void SaveLoadGameProgress()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            saveLoadSystem.SaveGameProgress(CharactersWalkOrderList[0]);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            saveLoadSystem.LoadGameProgress(CharactersWalkOrderList[0]);
        }
    }

    public void TurnOffAllLeaders()
    {
        for (int i = 0; i < uIManager.CharacterButtonsList.Count; i++)
        {
            uIManager.CharacterButtonsList[i].TurnOffLeader();
        }

        for (int j = 0; j < charactersManager.CharactersList.Count; j++)
        {
            charactersManager.CharactersList[j].ResetStartPathColor();           
        }
    }

    public void GetCharacterPath()
    {
        aStarPathfinding.CharacterPath();
    }

    public void GetCharactersOrderList()
    {
        charactersManager.SetCharactersOrder();
    }

    public void AssignCostsValues(PathNode endNode)
    {
        string gCost = $"{gCostText.text} {endNode.GCost}";
        gCostText.text = gCost;

        string hCost = $"{hCostText.text} {endNode.HCost}";
        hCostText.text = hCost;

        string fCost = $"{fCostText.text} {endNode.FCost}";
        fCostText.text = fCost;
    }
}
