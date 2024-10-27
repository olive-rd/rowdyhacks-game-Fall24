using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostMode : MonoBehaviour
{
    public GameData gameData;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gameData.boostPercent>=gameData.maxBoostPercent && !gameData.boostActive)
            StartBoost();
        if(gameData.boostActive)
            UpdateBoost();

    }
    void StartBoost()
    {
        gameData.boostActive = true;
        Debug.Log("Boost!");
        //change pngs or something
        //change speed
    }
    void UpdateBoost()
    {
        if(gameData.boostPercent <= 0)
            ExitBoost();
    }
    void ExitBoost()
    {
        gameData.boostActive = false;
    }
}
