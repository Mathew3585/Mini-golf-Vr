using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BallManager : MonoBehaviour
{
    private FxManager fxManager;

    // Start is called before the first frame update
    void Awake()
    {
        fxManager = FindObjectOfType<FxManager>();
        Instantiate(fxManager.CurrentTrail, transform);
    }
}
