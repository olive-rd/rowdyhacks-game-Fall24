using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //----testing variables, replace later ----
    public int speed;

    //----end testing variables------

    public float score;

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
        score += Time.deltaTime * speed;
    }

    void UpdateBoost()
    {
        //if not boosting, boost bar increases. if boosting, boost bar depletes
        if(boostPercent< maxBoostPercent && !boostActive)
            boostPercent += (Time.deltaTime * speed) /2;
        else if(boostActive)
            boostPercent -= (Time.deltaTime * speed);
    }
}
