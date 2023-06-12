using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMananger : MonoBehaviour
{

    private int currentHoleNumber = 0;

    public List<Transform> startingPosition;


    public Rigidbody ballRidgibody;

    public GameObject ArrowUi;
    public GameObject CanvasBall;
    private GameObject Player;

    public int currentHitNuber = 0;
    private List<int> previousHitNumbers = new List<int>();

    public TextMeshPro textMeshPro;

    private AddSpeedClub club;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        club = FindObjectOfType<AddSpeedClub>();
    }


    // Start is called before the first frame update
    void Start()
    {
        ballRidgibody.transform.position = startingPosition[currentHoleNumber].position;
        ArrowUi.SetActive(true);
        club.FirstTap = true;
        ballRidgibody.velocity = Vector3.zero;
        ballRidgibody.angularVelocity = Vector3.zero;
        textMeshPro.text = "";
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(club.FirstTap)
        {
            Vector3 direction = Player.transform.position - ArrowUi.transform.position;
            CanvasBall.transform.rotation = Quaternion.Euler(0f, direction.y, 0f);
        }
    }

    public void GotoNextHole()
    {
        currentHoleNumber++;
        ArrowUi.SetActive(true);
        club.FirstTap = true;
        if (currentHoleNumber >= startingPosition.Count)
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
