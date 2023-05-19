using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    private int currentHoleNumber = 0;

    public List<Transform> startingPosition;

    public Rigidbody ballRidgibody;


    public int currentHitNuber = 0;
    private List<int> previousHitNumbers = new List<int>();

    public TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        ballRidgibody.transform.position = startingPosition[currentHoleNumber].position;
        ballRidgibody.velocity = Vector3.zero;
        ballRidgibody.angularVelocity = Vector3.zero;
        textMeshPro.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoNextHole()
    {
        currentHoleNumber++;

        if(currentHoleNumber >= startingPosition.Count)
        {
            Debug.Log("We reached the end");
        }
        else
        {
            ballRidgibody.transform.position = startingPosition[currentHoleNumber].position;
            ballRidgibody.velocity = Vector3.zero;
            ballRidgibody.angularVelocity = Vector3.zero;
        }

        previousHitNumbers.Add(currentHitNuber);
        currentHitNuber = 0;

        Dispalyscore();
    }

    public void Dispalyscore()
    {
        string score = "";

        for (int i = 0; i < previousHitNumbers.Count; i++)
        {
            score += "HOLE" + (i + 1) + " - " + previousHitNumbers[i] + "<br>";
        }

        textMeshPro.text = score;
    } 
}
