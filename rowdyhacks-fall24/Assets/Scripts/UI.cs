using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //      --for testing, replace later---

    //boost meter
    public float maxBoostPercent;
    public Image meter;
    [SerializeField]
    public float boostMeter;

    //score
    [SerializeField]
    public int score;

    //---end testing vars


    public Text scoreText;

    private void Update()
    {
        UpdateBoostFill();
        UpdateScore();
    }

    void UpdateBoostFill()
    {
        float fillAmount = boostMeter / maxBoostPercent;
        meter.fillAmount = fillAmount;
    }

    void UpdateScore()
    {
        scoreText.text = "Score " + score;
    }
    
}
