using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private MeshRenderer cudeNode;

    [SerializeField] private LayerMask walkableLayer;

    private Color32 defaultColor;
    private Color32 hoverOverColor = new Color32(253, 127, 57, 255);

    private bool isWalkable = false;

    private AStarPathfinding aStarPathfinding;

    public bool IsWalkable { get { return isWalkable; } }

    private void Start()
    {
        defaultColor = cudeNode.material.color;
        aStarPathfinding = transform.parent.GetComponent<AStarPathfinding>();
        
        if (1 << gameObject.layer == walkableLayer)
        {
            isWalkable = true;
        }
    }

    private void Update()
    {
        
    }

    public void SetDefaultColor()
    {
        cudeNode.material.color = defaultColor;
    }

    public void SetHoverOverColor()
    {
        cudeNode.material.color = hoverOverColor;
    }
}
