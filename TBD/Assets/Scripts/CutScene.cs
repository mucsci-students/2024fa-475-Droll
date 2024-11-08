/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    public int cutSceneNo;
    private int lastSceneNo;

    private Image currentImage;
    private Text currentText;
    public Image redImagePrefab;
    public Text redTextPrefab;
    public Image blueImagePrefab;
    public Text blueTextPrefab;
    public Image grayImagePrefab;
    public Text grayTextPrefab;
    
    void Start()
    {
        cutSceneNo = 0;
        lastSceneNo = 0;
    }

    void Update()
    {
        // If the boss death count has changed, change the cut scene number and run it
        if (cutSceneNo != lastSceneNo) {
            lastSceneNo = cutSceneNo;
            runScene(cutSceneNo);
        }
    }

    // Executes a specified cut scene
    void runScene(int num) {
        Time.timeScale = 0;
        if (num == 0) {
            // Scene at the beginning of the game
        } else if (num == 1) {
            // Scene after the boss dies the first time
        } else if (num == 2) {
            // Scene after the boss dies the second time
        } else if (num == 3) {
            // Scene after the boss dies the third time
        } else if (num == 4) {
            // Scene after the boss dies the fourth time
        } else {
            // Scene for every time after
        }
        Time.timeScale = 1;
    }

    // Displays speech from the red side
    void redSays(string phrase) {
        // Create the red sprite image and the phrase text
        currentImage = Instantiate(redImagePrefab, canvas.transform);
        currentText = Instantiate(redTextPrefab, canvas.transform);

        // Set the image sprite to "redSprite.png" as a file name placeholder
        currentImage.sprite = Resources.Load<Sprite>("redSprite"); // Assuming the sprite is in the Resources folder

        // Set the phrase text
        currentText.text = phrase;

        // Positioning
        currentImage.rectTransform.anchoredPosition = new Vector2(0, 0); // Placeholder position of the image
        currentText.rectTransform.anchoredPosition = new Vector2(0, -0); // Placeholder position of the text

        // Once space bar is pressed, destroy the image and text
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            // Do Nothing
        }
        Destroy(currentImage.gameObject);
        Destroy(currentText.gameObject);
    }

    // Displays speech from the blue side
    void blueSays(string phrase) {
        // Create the red sprite image and the phrase text
        currentImage = Instantiate(blueImagePrefab, canvas.transform);
        currentText = Instantiate(blueTextPrefab, canvas.transform);

        // Set the image sprite to "blueSprite.png" as a file name placeholder
        currentImage.sprite = Resources.Load<Sprite>("blueSprite"); // Assuming the sprite is in the Resources folder

        // Set the phrase text
        currentText.text = phrase;

        // Positioning
        currentImage.rectTransform.anchoredPosition = new Vector2(0, 0); // Placeholder position of the image
        currentText.rectTransform.anchoredPosition = new Vector2(0, -0); // Placeholder position of the text

        // Once space bar is pressed, destroy the image and text
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            // Do Nothing
        }
        Destroy(currentImage.gameObject);
        Destroy(currentText.gameObject);
    }

    // Displays speech from the gray side
    void graySays(string phrase) {
        // Create the red sprite image and the phrase text
        currentImage = Instantiate(grayImagePrefab, canvas.transform);
        currentText = Instantiate(grayTextPrefab, canvas.transform);

        // Set the image sprite to "graySprite.png" as a file name placeholder
        currentImage.sprite = Resources.Load<Sprite>("graySprite"); // Assuming the sprite is in the Resources folder

        // Set the phrase text
        currentText.text = phrase;

        // Positioning
        currentImage.rectTransform.anchoredPosition = new Vector2(0, 0); // Placeholder position of the image
        currentText.rectTransform.anchoredPosition = new Vector2(0, -0); // Placeholder position of the text

        /// Once space bar is pressed, destroy the image and text
        while (!Input.GetKeyDown(KeyCode.Space))
        {
            // Do Nothing
        }
        Destroy(currentImage.gameObject);
        Destroy(currentText.gameObject);
    }
}
*/