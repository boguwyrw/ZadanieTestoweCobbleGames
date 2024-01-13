using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IFollow
{
    [SerializeField] private GameObject leaderMarker;

    [SerializeField] private LayerMask groundLayer;

    private float speed = 0.0f;
    private float agility = 0.0f;
    private float strength = 0.0f;

    private PathNode currentPathNode = null;

    public bool IsLeading { set; get; } = false;

    [HideInInspector] public bool IsPathCheck = false;

    private void Start()
    {

    }

    private void Update()
    {
        leaderMarker.SetActive(IsLeading);
    }

    private void FixedUpdate()
    {
        if (IsPathCheck)
        {
            RaycastHit hit;
            Vector3 startRaycast = transform.position + Vector3.up;
            if (Physics.Raycast(startRaycast, Vector3.down, out hit, 2.0f, groundLayer))
            {
                IsPathCheck = false;
                currentPathNode = hit.transform.GetComponent<PathNode>();
                currentPathNode.SetStartColor();
            }
        }
    }

    public void ResetStartPathColor()
    {
        if (currentPathNode != null)
        {
            currentPathNode.SetDefaultColor();
            currentPathNode = null;
        }
    }

    public void FollowLeader(Vector3 leaderPosition)
    {
        if (!IsLeading)
        {

        }
    }
}
