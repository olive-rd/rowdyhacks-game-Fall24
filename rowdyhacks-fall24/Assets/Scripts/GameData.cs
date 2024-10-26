using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    //----testing variables, replace later ----
    public int speed;

    //----end testing variables------

    public float score;
    public float boostPercent;
    public float maxBoostPercent;

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
        if(boostPercent< maxBoostPercent)
            boostPercent += (Time.deltaTime * speed) /2;
    }
}
