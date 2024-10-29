using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    //[SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject blueWin;
    [SerializeField] GameObject redWin;
    [SerializeField] GameObject howToPlay;


    bool gameOver;
    bool blueWinBool;
    // Start is called before the first frame update
    void Start()
    {
        blueWin.SetActive(false);
        redWin.SetActive(false);
        pauseMenu.SetActive(false);
        howToPlay.SetActive(false);
        //Time.timeScale = 0f;
        //mainMenu.SetActive(true);
        gameOver = false;
        blueWinBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            EndScreen();
        }
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        //Open pause menu
    }
    public void ResumeTheGame()
    {
        //Close pause menu.
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        howToPlay.SetActive(false);
        pauseButton.SetActive(true);
    }
    public void ExitToMenu()
    {
        //Go to main menu
        SceneManager.LoadScene(1);
    }
    public void Instructions()
    {
        pauseMenu.SetActive(false);
        howToPlay.SetActive(true);
    }
    public void ReturnToPause()
    {
        pauseMenu.SetActive(true);
        howToPlay.SetActive(false);
    }
    public void EndScreen()
    {   
       if(blueWinBool)
       {
        blueWin.SetActive(true);
       } 
       else
       {
        redWin.SetActive(true);
       }
    }
}
