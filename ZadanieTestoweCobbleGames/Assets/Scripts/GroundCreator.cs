using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using System.IO;

public class GroundCreator : MonoBehaviour
{
    private const char PATH_NODE_WALKABLE_SIGN = 'o';

    [SerializeField] private AssetReferenceGameObject pathNodeWalkableReference;
    [SerializeField] private AssetReferenceGameObject pathNodeNotWalkableReference;

    [SerializeField] private LayerMask walkableLayerMask;

    private int gridX = 0;
    private int gridZ = 0;

    private List<string> pathNodeLines = new List<string>();

    private List<PathNode> walkablePathNode = new List<PathNode>();

    public int GridX { get { return gridX; } }
    public int GridZ { get { return gridZ; } }

    public List<PathNode> WalkablePathNode { get { return walkablePathNode; } }

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

        gridX = pathNodeLines[0].Length;
        gridZ = pathNodeLines.Count;

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

        for (int pn = 0; pn < transform.childCount; pn++)
        {
            if (1 << transform.GetChild(pn).gameObject.layer == walkableLayerMask)
            {
                PathNode walkablePN = transform.GetChild(pn).GetComponent<PathNode>();
                walkablePathNode.Add(walkablePN);
            }
        }
    }

    private void Update()
    {
        
    }

    public PathNode GetPathNode(int x, int z)
    {
        PathNode pn = null;
        for (int i = 0; i < walkablePathNode.Count; i++)
        {
            if (walkablePathNode[i].PositionX == x && walkablePathNode[i].PositionZ == z)
            {
                pn = walkablePathNode[i];
            }
        }

        return pn;
    }
}
