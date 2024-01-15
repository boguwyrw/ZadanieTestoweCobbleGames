using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IFollow
{
    [SerializeField] private GameObject leaderMarker;

    [SerializeField] private LayerMask groundLayer;

    private float speedMinRange = 0.5f;
    private float speedMaxRange = 2.0f;
    private float speed = 0.0f;

    private float agilityMinRange = 2.0f;
    private float agilityMaxRange = 8.0f;
    private float agility = 0.0f;

    private float strengthMinRange = 3.0f;
    private float strengthMaxRange = 10.0f;
    private float strength = 0.0f;

    private int waypointIndex = 0;

    private PathNode currentPathNode = null;

    public bool IsLeading { set; get; } = false;

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

        CharacterMovement();
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

    private void CharacterMovement()
    {
        /*
        if (GameManager.Instance.CanStartMove)
        {
            Vector3 targetPosition = GameManager.Instance.GetCharacterPath()[waypointIndex];
            if (Vector3.Distance(targetPosition, transform.position) > 0.1f && waypointIndex < GameManager.Instance.GetCharacterPath().Count - 1)
            {
                transform.Translate(transform.forward * speed * Time.deltaTime);           
                RotateTowardsWaypoint(targetPosition);
            }
        }
        */
        if (GameManager.Instance.CanStartMove)
            RotateTowardsWaypoint(new Vector3(6, 0, 4));
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
        if (!IsLeading)
        {

        }
    }
}
