using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private PathNode pathNode = null;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (pathNode != null)
        {
            pathNode.SetDefaultColor();
            pathNode = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Transform selectionPathNode = hit.transform;
            pathNode = selectionPathNode.GetComponent<PathNode>();
            if (pathNode != null)
                pathNode.SetHoverOverColor();
        }
    }
}
