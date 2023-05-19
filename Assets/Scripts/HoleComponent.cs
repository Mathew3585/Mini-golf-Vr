using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleComponent : MonoBehaviour
{

    private GameMananger gameMananger;
    public string targetTag = "ball";

    private void Awake()
    {
        gameMananger = FindObjectOfType<GameMananger>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            gameMananger.GotoNextHole();
        }
    }
}
