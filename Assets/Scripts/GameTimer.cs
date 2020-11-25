using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float timeStart = 0f;
    public Text gameCounter;
    public GameObject enemyColor;
    public GameObject surviveMessage;

    private string round;
    public GameObject winner;
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        gameCounter.text = timeStart.ToString("F2");
        round = PlayerPrefs.GetString("Game", round);

        GameSave();
    }

    // Update is called once per frame
    void Update()
    {

        timeStart += Time.deltaTime;
        if (timeStart >= 1.5f)
        {
            surviveMessage.SetActive(false);
        }
        if (timeStart >= 240f)
        {
            var rotationVector = transform.rotation.eulerAngles; //rotate the directional light object to change the angle of the lighting
            rotationVector.x = 0;
            transform.rotation = Quaternion.Euler(rotationVector);
        }
        if (timeStart >= 300f)
        {
            enemyColor.GetComponent<ChangeColor>().enabled = true; //call changecolor script to get the value
        }

        if (timeStart >= 360f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (timeStart >= 359f && SceneManager.GetActiveScene().buildIndex == 10)
        {
            winner.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
        gameCounter.text = timeStart.ToString("F2");

    }

    void GameSave()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            round = "Game1";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            round = "Game2";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            round = "Game3";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            round = "Game4";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            round = "Game5";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            round = "Game6";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            round = "Game7";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            round = "Game8";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            round = "Game9";
            PlayerPrefs.SetString("Game", round);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            round = "Game10";
            PlayerPrefs.SetString("Game", round);
        }
    }
}