using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.IO;

public class GroundCreator : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject pathNodeWalkableReference;
    [SerializeField] private AssetReferenceGameObject pathNodeNotWalkableReference;

    private List<string> pathNodeLines = new List<string>();

    private const char PATH_NODE_WALKABLE_SIGN = 'o';

    private void Start()
    {
        string filePath = Application.dataPath + @"\Files\ground.txt";
        using (StreamReader sr = File.OpenText(filePath))
        {
            string s = "";
            while ((s = sr.ReadLine()) != null)
            {
                pathNodeLines.Add(s);
            }
        }
        
        for (int i = 0; i < pathNodeLines.Count; i++)
        {
            for (int j = 0; j < pathNodeLines[i].Length; j++)
            {
                if (pathNodeLines[i][j] == PATH_NODE_WALKABLE_SIGN)
                {
                    pathNodeWalkableReference.InstantiateAsync(new Vector3(j, 0.0f, i), Quaternion.identity, transform);
                }
                else
                {
                    pathNodeNotWalkableReference.InstantiateAsync(new Vector3(j, 0.0f, i), Quaternion.identity, transform);
                }
            }
        }
    }

    private void Update()
    {
        
    }
}