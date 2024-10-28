using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{

    public void StartGameNow()
    {
        SceneManager.LoadScene(0);
    }
    public void Instructions()
    {
        //Open instruction menu.
    }
    public void Settings()
    {
        //Settings menu
    }
}

