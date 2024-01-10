using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class CharactersManager : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject characterPrefab;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void CreateCharacter(int characters)
    {
        for (int i = 0; i < characters; i++)
        {
            characterPrefab.InstantiateAsync(new Vector3(i, 0.0f, 0.0f), Quaternion.identity);
        }
    }
}
