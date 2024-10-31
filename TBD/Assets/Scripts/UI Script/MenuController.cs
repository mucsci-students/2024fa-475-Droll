using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MenuController : MonoBehaviour
{
    //[SerializeField] GameObject mainMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject blueWin;
    [SerializeField] GameObject redWin;
    [SerializeField] GameObject howToPlay;
    [SerializeField] TMP_Text blueH;
    [SerializeField] TMP_Text redH;
    [SerializeField] TMP_Text blueM;
    [SerializeField] TMP_Text redM;
    [SerializeField] TMP_Text enemyLeft;

    bool blueWinBool;
    public int moneyBlue;
    public int moneyRed;
    public int healthBlue;
    public int healthRed;
    public LeftWall leftWallScript;
    public GameObject leftWall;
    public RightWall rightWallScript;
    public GameObject rightWall;
    public RedMoveScript redGuyScript;
    public GameObject redGuy;
    public BlueMoveScript blueGuyScript;
    public GameObject blueGuy;
    public GraySpawning grayManager;
    public GameObject bossTimer;
    public int killsLeft;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        leftWall = GameObject.Find("left wall");
        leftWallScript = leftWall.GetComponent<LeftWall>();
        rightWall = GameObject.Find("right wall");
        rightWallScript = rightWall.GetComponent<RightWall>();
        redGuy = GameObject.Find("RedGuy");
        redGuyScript = redGuy.GetComponent<RedMoveScript>();
        blueGuy = GameObject.Find("BlueGuy");
        blueGuyScript = blueGuy.GetComponent<BlueMoveScript>();
        bossTimer = GameObject.Find("GrayManager");
        grayManager = bossTimer.GetComponent<GraySpawning>();
        blueWin.SetActive(false);
        redWin.SetActive(false);
        pauseMenu.SetActive(false);
        howToPlay.SetActive(false);
        blueWinBool = true;
        moneyBlue = blueGuyScript.money;
        moneyRed = redGuyScript.money;
        healthBlue = rightWallScript.health;
        healthRed = leftWallScript.health;
        killsLeft = grayManager.bossTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if((healthBlue<=0 || healthRed<=0))
        {
            blueWinBool = (healthRed <= 0);
            Time.timeScale = 0f;
            EndScreen();
        }
        moneyBlue = blueGuyScript.money;
        moneyRed = redGuyScript.money;
        healthBlue = rightWallScript.health;
        healthRed = leftWallScript.health;
        killsLeft = grayManager.bossTimer;
        
        MoneyCountBlue();
        MoneyCountRed();
        HealthCountBlue();
        HealthCountRed();
        killsNeeded();
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
        //Time.timeScale = 0f;
       if(blueWinBool)
       {
        blueWin.SetActive(true);
       } 
       else
       {
        redWin.SetActive(true);
       }
    }
    public void MoneyCountBlue()
    {
        blueM.text = "$" + moneyBlue;
    }
    public void MoneyCountRed()
    {
        redM.text = "$" + moneyRed;
    }
    public void HealthCountBlue()
    {
        blueH.text = "Health = " + healthBlue;
    }
    public void HealthCountRed()
    {
        redH.text = "Health = " + healthRed;
    }
    public void killsNeeded()
    {
        enemyLeft.text = killsLeft + " kills remaining until boss spawn";
    }
}
