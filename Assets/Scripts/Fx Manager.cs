using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    public GameObject CurrentTrail;
    public GameObject CurrentFxGoal;

    [Header("Trail")]
    public GameObject TrailWhite;
    public GameObject TrailBleu;
    public GameObject TrailRouge;
    public GameObject TrailVert;
    public GameObject TrailJaune;
    public GameObject TrailViolet;
    public GameObject TrailRgb;

    [Space(10)]
    [Header("FX Goal")]
    public GameObject FxGoalConfetieWhite;
    public GameObject FxGoalConfetieRed;
    public GameObject FxGoalConfetieBlue;
    public GameObject FxGoalConfetieGreen;
    public GameObject FxGoalConfetieYellow;
    public GameObject FxGoalConfetieViolet;
    public GameObject FxGoalConfetieRgb;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
