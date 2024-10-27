using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    //      --for testing, replace later---

    //boost meter
    public Image boostMeter;

    //---end testing vars

    public GameData gameData;

    public Text scoreText;

    private void Update()
    {
        UpdateBoostFill();
        UpdateScore();
    }

    void UpdateBoostFill()
    {
        float fillAmount = gameData.boostPercent / gameData.maxBoostPercent;
        boostMeter.fillAmount = fillAmount;
    }

    void UpdateScore()
    {
        scoreText.text = "Score " + (int)gameData.score;
    }
    
}
