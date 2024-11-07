using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class MenuController : MonoBehaviour
{
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
    public int unitBlue;
    public int unitRed;

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
    public RedUnitSelector redUnitCur;
    public GameObject redUnitManager;
    public BlueUnitSelector blueUnitCur;
    public GameObject blueUnitManager;
    public GameObject redOutlineOne;
    public GameObject redOutlineTwo;
    public GameObject redOutlineThree;
    public GameObject redOutlineFour;
    public GameObject blueOutlineOne;
    public GameObject blueOutlineTwo;
    public GameObject blueOutlineThree;
    public GameObject blueOutlineFour;

    // Start is called before the first frame update
    void Start()
    {
        //Set vars for helper functions.
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
        blueUnitManager = GameObject.Find("BlueUnitManager");
        blueUnitCur = blueUnitManager.GetComponent<BlueUnitSelector>();
        redUnitManager = GameObject.Find("RedUnitManager");
        redUnitCur = redUnitManager.GetComponent<RedUnitSelector>();
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
        unitBlue = 1;
        unitRed = 1;
        redOutlineOne = GameObject.Find("outlineRedOne");
        redOutlineTwo = GameObject.Find("outlineRedTwo");
        redOutlineThree = GameObject.Find("outlineRedThree");
        redOutlineFour = GameObject.Find("outlineRedFour");
        blueOutlineOne = GameObject.Find("outlineBlueOne");
        blueOutlineTwo = GameObject.Find("outlineBlueTwo");
        blueOutlineThree = GameObject.Find("outlineBlueThree");
        blueOutlineFour = GameObject.Find("outlineBlueFour");
        updateSelect();

    }

    // Update is called once per frame
    void Update()
    {
        //Check if game should end
        if((healthBlue<=0 || healthRed<=0))
        {
            blueWinBool = (healthRed <= 0);
            Time.timeScale = 0f;
            EndScreen();
        }
        //Update vars.
        moneyBlue = blueGuyScript.money;
        moneyRed = redGuyScript.money;
        healthBlue = rightWallScript.health;
        healthRed = leftWallScript.health;
        killsLeft = grayManager.bossTimer;
        

        //Call helper functions.
        MoneyCountBlue();
        MoneyCountRed();
        HealthCountBlue();
        HealthCountRed();
        killsNeeded();
        if(unitBlue != blueUnitCur.currentUnit || unitRed != redUnitCur.currentUnit)
        {
            updateSelect();
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
        //Bring up instruction menu.
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
    public void updateSelect()
    {
    if(unitRed != redUnitCur.currentUnit)
    {
        unitRed = redUnitCur.currentUnit;
        redOutlineOne.SetActive(false);
        redOutlineTwo.SetActive(false);
        redOutlineThree.SetActive(false);
        redOutlineFour.SetActive(false);
        if(unitRed == 0)
            redOutlineOne.SetActive(true);
            else
            if(unitRed == 1)
                redOutlineTwo.SetActive(true);
                else
                if(unitRed == 2)
                    redOutlineThree.SetActive(true);
                    else
                    redOutlineFour.SetActive(true);
    }
    if(unitBlue != blueUnitCur.currentUnit)
    {
        unitBlue = blueUnitCur.currentUnit;
        blueOutlineOne.SetActive(false);
        blueOutlineTwo.SetActive(false);
        blueOutlineThree.SetActive(false);
        blueOutlineFour.SetActive(false);
        if(unitBlue == 0)
            blueOutlineOne.SetActive(true);
            else
            if(unitBlue == 1)
                blueOutlineTwo.SetActive(true);
                else
                if(unitBlue == 2)
                    blueOutlineThree.SetActive(true);
                    else
                    blueOutlineFour.SetActive(true);
    }

    }

}
