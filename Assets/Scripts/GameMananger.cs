using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    [Header("Player")]
    public Transform LeftHand;
    public Transform RightHand;
    public GameObject Club;




    private int currentHoleNumber = 0;

    [Space(10)]
    [Header("BallParameter")]
    public List<Transform> startingPosition;


    public Rigidbody ballRidgibody;

    [Space(10)]
    [Header("Ball Ui")]
    public GameObject ArrowUi;
    public GameObject CanvasBall;
    public GameObject Player;

    [Space(10)]
    [Header("HitNuber")]
    public int currentHitNuber = 0;
    


    [Space(10)]
    [Header("Ball Ui")]
    public TextMeshPro textMeshPro;


    private List<int> previousHitNumbers = new List<int>();
    private AddSpeedClub club;
    private PlayerParamterManager playerParamter;

    private void Awake()
    {
        playerParamter = FindObjectOfType<PlayerParamterManager>();
        if (playerParamter.PlayerLeftHand)
        {
            Instantiate(Club, LeftHand);
        }
        else if (playerParamter.PlayerRightHnad)
        {
            Instantiate(Club, RightHand);
        }
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
            Vector3 dir = new Vector3(0f, Quaternion.LookRotation(direction).eulerAngles.y, 0f);
            CanvasBall.transform.localRotation = Quaternion.Euler(dir) * Quaternion.Euler(0f, 90f, 0f);
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
