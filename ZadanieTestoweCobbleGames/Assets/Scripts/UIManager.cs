using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class UIManager : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject buttonPrefab;

    [SerializeField] private Transform content;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void CreateButton(int characters)
    {
        for (int i = 0; i < characters; i++)
        {
            buttonPrefab.InstantiateAsync(content);
        }
    }
}
