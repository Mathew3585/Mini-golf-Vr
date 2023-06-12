using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleComponent : MonoBehaviour
{

    private GameMananger gameMananger;
    private MoneyManager moneyManager;
    public string targetTag = "ball";
    public int DropMoney;

    private void Awake()
    {
        gameMananger = FindObjectOfType<GameMananger>();
        moneyManager = FindObjectOfType<MoneyManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(targetTag))
        {
            moneyManager.PlayerMoney += DropMoney;
            gameMananger.GotoNextHole();
        }
    }
}
