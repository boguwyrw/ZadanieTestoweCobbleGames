using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IFollow
{
    [SerializeField] private GameObject leaderMarker;

    [SerializeField] private LayerMask groundLayer;

    private float minDistanceToTarget = 0.05f;
    private float raycastLength = 2.0f;

    private float speedMinRange = 0.5f;
    private float speedMaxRange = 2.0f;
    private float speed = 0.0f;

    private float agilityMinRange = 6.0f;
    private float agilityMaxRange = 10.0f;
    private float agility = 0.0f;

    private float strengthMinRange = 3.0f;
    private float strengthMaxRange = 10.0f;
    private float strength = 0.0f;

    private int waypointIndex = 0;

    private Vector3 previousPosition;

    private PathNode currentPathNode = null;

    public bool IsLeading { get; set; } = false;

    public int SetIndex { get; set; }

    [HideInInspector] public bool IsPathCheck = false;

    private void Start()
    {
        speed = Random.Range(speedMinRange, speedMaxRange);
        agility = Random.Range(agilityMinRange, agilityMaxRange);
        strength = Random.Range(strengthMinRange, strengthMaxRange);
    }

    private void Update()
    {
        leaderMarker.SetActive(IsLeading);

        if (GameManager.Instance.CanStartMove)
        {
            if (IsLeading)
            {
                CharacterMovement();
                for (int i = 1; i < GameManager.Instance.CharactersWalkOrderList.Count; i++)
                {
                    IFollow follow = GameManager.Instance.CharactersWalkOrderList[i];
                    follow.FollowLeader(previousPosition);
                }
            }
        }   
    }

    private void FixedUpdate()
    {
        if (IsPathCheck)
        {
            RaycastHit hit;
            Vector3 startRaycast = transform.position + Vector3.up;
            if (Physics.Raycast(startRaycast, Vector3.down, out hit, raycastLength, groundLayer))
            {
                IsPathCheck = false;
                currentPathNode = hit.transform.GetComponent<PathNode>();
                currentPathNode.SetStartColor();
            }
        }
    }

    private void CharacterMovement()
    {
        Vector3 targetPosition = GameManager.Instance.CharacterPathList[waypointIndex];
        RotateTowardsWaypoint(targetPosition);

        if (Vector3.Distance(targetPosition, transform.position) > minDistanceToTarget)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (waypointIndex < GameManager.Instance.CharacterPathList.Count - 1)
        {
            waypointIndex++;
            previousPosition = GameManager.Instance.CharacterPathList[waypointIndex - 1];
        }
    }

    private void RotateTowardsWaypoint(Vector3 waypoint)
    {
        Vector3 directionToWaypoint = (waypoint - transform.position).normalized;
        Quaternion rotationGoal = Quaternion.LookRotation(directionToWaypoint);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, agility * Time.deltaTime);
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
        RotateTowardsWaypoint(leaderPosition);

        if (Vector3.Distance(leaderPosition, transform.position) > minDistanceToTarget)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
