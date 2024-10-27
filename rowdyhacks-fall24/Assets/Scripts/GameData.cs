using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{

    public float score;
    public float forwardSpeed = 5f;      // Speed at which the car moves automatically from left to right
    //boost data
    public bool boostActive;
    public float boostPercent;
    public float maxBoostPercent;


    private void Start()
    {
        score = 0;
        boostActive = false;
    }
    private void Update()
    {
        UpdateScore();
        UpdateBoost();
    }

    void UpdateScore()
    {
        score += (forwardSpeed);
    }

    void UpdateBoost()
    {
        //if not boosting, boost bar increases. if boosting, boost bar depletes
        if(boostPercent< maxBoostPercent && !boostActive)
            boostPercent += (Time.deltaTime * forwardSpeed) /2;
        else if(boostActive)
            boostPercent -= (Time.deltaTime * forwardSpeed);
    }
}
