using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameData gameData;

    public enum Buff
    {
        None,
        Slowed,
        Spinning
    }
    public Buff currentBuff = Buff.None;

    public float speedDecrement = 2.0f;

    private void Update()
    {
        if (currentBuff == Buff.Spinning)
            UpdateSpin();
    }

    void ExitCurrent(Buff buff)
    {
        switch (buff)
        {
            case Buff.Spinning:
                ExitSpin();
                break;
            case Buff.Slowed:
                ExitSlowed();
                break;
        }
    }

    public void StartSlowed()
    {
        Debug.Log("start slow");
        ExitCurrent(currentBuff);
        currentBuff = Buff.Slowed;
        gameData.forwardSpeed /= speedDecrement;
        StartCoroutine(SlowedCountdown());
    }
    IEnumerator SlowedCountdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ExitSlowed();
        }
    }
    void ExitSlowed()
    {
        Debug.Log("Exit slow");
        currentBuff = Buff.None;
        gameData.forwardSpeed *= speedDecrement;
    }
    public void StartSpin()
    {
        ExitCurrent(currentBuff);
        currentBuff = Buff.Spinning;
        gameData.forwardSpeed /= speedDecrement;
    }
    public void UpdateSpin()
    {
        if(transform.localEulerAngles.z >90 && transform.localEulerAngles.z < 100)
        {
            ExitSpin();
            return;
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z-2);
    }
    public void ExitSpin()
    {
        currentBuff = Buff.None;
        gameData.forwardSpeed *= speedDecrement;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 90);
    }
}
