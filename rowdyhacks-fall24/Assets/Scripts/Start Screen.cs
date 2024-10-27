using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public SceneManager sceneManager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Car movement", LoadSceneMode.Single);
    }
}
