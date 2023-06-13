using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParamterManager : MonoBehaviour
{
    public bool PlayerLeftHand;
    public bool PlayerRightHnad;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
