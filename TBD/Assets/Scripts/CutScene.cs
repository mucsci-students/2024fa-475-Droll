using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CutScene : MonoBehaviour
{
    public int cutSceneNo;
    private int lastSceneNo;
    public Canvas canvas;

    private Image currentImage;
    private TextMeshProUGUI currentText;
    public Image redImagePrefab;
    public TextMeshProUGUI redTextPrefab;
    public Image blueImagePrefab;
    public TextMeshProUGUI blueTextPrefab;
    public Image grayImagePrefab;
    public TextMeshProUGUI grayTextPrefab;
    
    void Start()
    {
        cutSceneNo = 0;
        lastSceneNo = -1;
    }

    void Update()
    {
        // If the boss death count has changed, change the cut scene number and run it
        if (cutSceneNo != lastSceneNo) {
            lastSceneNo = cutSceneNo;
            StartCoroutine(RunScene(cutSceneNo));
        }
    }

    // Executes a specified cut scene
    private IEnumerator RunScene(int num) {
        Debug.Log($"In the RunScene");
        Time.timeScale = 0;
        if (num == 0) {
            Debug.Log($"In the First scene");
            yield return StartCoroutine(RedSays("Testing red says"));
            yield return StartCoroutine(BlueSays("Testing blue says"));
            yield return StartCoroutine(GraySays("Gray says to verify coords"));
        } else if (num == 1) {
            yield return StartCoroutine(RedSays("Boss first death works"));
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
    private IEnumerator RedSays(string phrase) {
        // Create the red sprite image and the phrase text
        currentImage = Instantiate(redImagePrefab, canvas.transform);
        currentText = Instantiate(redTextPrefab, canvas.transform);

        // Set the image sprite to "redSprite.png" as a file name placeholder
        currentImage.sprite = Resources.Load<Sprite>("Red"); // Assuming the sprite is in the Resources folder

        // Set the phrase text
        currentText.text = phrase;

        // Positioning
        currentImage.rectTransform.anchoredPosition = new Vector2(-585, -328); // Placeholder position of the image
        currentText.rectTransform.anchoredPosition = new Vector2(-575, -349); // Placeholder position of the text

        // Once space bar is pressed, destroy the image and text
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.Space)); // Wait for the key to be released

        Destroy(currentImage.gameObject);
        Destroy(currentText.gameObject);
    }

    // Displays speech from the blue side
    private IEnumerator BlueSays(string phrase) {
        // Create the red sprite image and the phrase text
        currentImage = Instantiate(blueImagePrefab, canvas.transform);
        currentText = Instantiate(blueTextPrefab, canvas.transform);

        // Set the image sprite to "blueSprite.png" as a file name placeholder
        currentImage.sprite = Resources.Load<Sprite>("Blue"); // Assuming the sprite is in the Resources folder

        // Set the phrase text
        currentText.text = phrase;

        // Positioning
        currentImage.rectTransform.anchoredPosition = new Vector2(-576, -328); // Placeholder position of the image
        currentText.rectTransform.anchoredPosition = new Vector2(-575, -349); // Placeholder position of the text

        // Once space bar is pressed, destroy the image and text
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.Space)); // Wait for the key to be released

        Destroy(currentImage.gameObject);
        Destroy(currentText.gameObject);
    }

    // Displays speech from the gray side
    private IEnumerator GraySays(string phrase) {
        // Create the red sprite image and the phrase text
        currentImage = Instantiate(grayImagePrefab, canvas.transform);
        currentText = Instantiate(grayTextPrefab, canvas.transform);

        // Set the image sprite to "graySprite.png" as a file name placeholder
        currentImage.sprite = Resources.Load<Sprite>("Gray"); // Assuming the sprite is in the Resources folder

        // Set the phrase text
        currentText.text = phrase;

        // Positioning
        currentImage.rectTransform.anchoredPosition = new Vector2(-581, -328); // Placeholder position of the image
        currentText.rectTransform.anchoredPosition = new Vector2(-575, -349); // Placeholder position of the text

        /// Once space bar is pressed, destroy the image and text
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.Space)); // Wait for the key to be released

        Destroy(currentImage.gameObject);
        Destroy(currentText.gameObject);
    }
}