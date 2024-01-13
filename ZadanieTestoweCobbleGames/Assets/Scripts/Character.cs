using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IFollow
{
    [SerializeField] private GameObject leaderMarker;

    private float speed = 0.0f;
    private float agility = 0.0f;
    private float strength = 0.0f;

    public bool IsLeading { set; get; } = false;

    private void Start()
    {

    }

    private void Update()
    {
        leaderMarker.SetActive(IsLeading);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void FollowLeader(Vector3 leaderPosition)
    {
        if (!IsLeading)
        {

        }
    }
}
