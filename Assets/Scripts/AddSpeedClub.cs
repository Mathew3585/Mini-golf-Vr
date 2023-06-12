using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedClub : MonoBehaviour
{

    public string targetTag;

    private Collider ClubCollider;
    private Vector3 Velocity;
    private Vector3 previousPosition;
    private GameMananger gameMananger;

    public bool FirstTap;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition= transform.position;
        ClubCollider = GetComponent<Collider>();
        gameMananger = FindObjectOfType<GameMananger>();
        FirstTap = true;
    }

    // Update is called once per frame
    void Update()
    {
        Velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            if (FirstTap)
            {
                gameMananger.ArrowUi.SetActive(false);
                FirstTap = false;
            }
            Vector3 collisonPosition = ClubCollider.ClosestPoint(other.transform.position);
            Vector3 collisonNoramlize = other.transform.position - collisonPosition;

            Vector3 projectedVelocity = Vector3.Project(Velocity, collisonNoramlize);

            Rigidbody rb = other.attachedRigidbody;
            rb.velocity = Velocity;

            gameMananger.currentHitNuber++;
        }
    }
}
