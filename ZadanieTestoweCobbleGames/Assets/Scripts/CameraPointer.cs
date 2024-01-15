using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPointer : MonoBehaviour
{
    private PathNode pathNode = null;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (pathNode != null)
            {
                pathNode.SetEndColor();
                GameManager.Instance.CanStartMove = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.CanStartMove)
        {
            PointPathNode();
        }
    }

    private void PointPathNode()
    {
        if (pathNode != null && !pathNode.IsUnavailable)
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
            bool isPathNodeAvailable = pathNode != null && pathNode.IsWalkable && !pathNode.IsUnavailable;
            if (isPathNodeAvailable)
            {
                pathNode.SetHoverOverColor();
            }
        }
    }
}
