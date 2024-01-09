using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    [SerializeField] private MeshRenderer cudeNode;

    private Color32 defaultColor;
    private Color32 hoverOverColor = new Color32(253, 127, 57, 255);

    private void Start()
    {
        defaultColor = cudeNode.material.color;
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
