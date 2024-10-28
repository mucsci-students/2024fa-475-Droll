using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        pauseButton.SetActive(true);
    }
    public void ExitToMenu()
    {
        //Go to main menu, close pause menu.
        Time.timeScale = 1f;
    }
    public void Instructions()
    {
        //Open instruction menu.
    }
    public void StartGame()
    {
        
    }
}
