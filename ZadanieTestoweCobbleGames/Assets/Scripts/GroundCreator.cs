using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GroundCreator : MonoBehaviour
{
    [SerializeField] private GameObject pathNodeWalkable;
    [SerializeField] private GameObject pathNodeNotWalkable;

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
                Debug.Log(pathNodeLines[i][j]);
                
                if (pathNodeLines[i][j] == PATH_NODE_WALKABLE_SIGN)
                {
                    Instantiate(pathNodeWalkable, new Vector3(j, 0.0f, i), Quaternion.identity, transform);
                }
                else
                {
                    Instantiate(pathNodeNotWalkable, new Vector3(j, 0.0f, i), Quaternion.identity, transform);
                }
            }
        }
    }

    private void Update()
    {
        
    }
}
