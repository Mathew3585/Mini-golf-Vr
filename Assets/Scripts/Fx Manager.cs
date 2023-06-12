using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public GameObject TrailBleu;
    public GameObject TrailRouge;
    public GameObject TrailVert;
    public GameObject TrailJaune;
    public GameObject TrailViolet;
    public GameObject TrailRgb;


    public GameObject FxGoalConfetie;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }
}
