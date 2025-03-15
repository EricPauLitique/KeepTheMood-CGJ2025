using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooMuchCars : MonoBehaviour
{
    public int nbCarToLoose = 30;

    private GameManager gm;

    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if(gm.nbEnemy >= nbCarToLoose)
        {
            gm.gameFinished();
        }
    }
}
