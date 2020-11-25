using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public int item;
    private string round;

    // Start is called before the first frame update
    void Start()
    {
        round = PlayerPrefs.GetString("Game", round);
    }

    public void MainMenu()
    {
        if (round.Equals("") | round.Equals("Game1"))
        {
            SceneManager.LoadScene("Game");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game2"))
        {
            SceneManager.LoadScene("Game 2");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game3"))
        {
            SceneManager.LoadScene("Game 3");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game4"))
        {
            SceneManager.LoadScene("Game 4");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game5"))
        {
            SceneManager.LoadScene("Game 5");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game6"))
        {
            SceneManager.LoadScene("Game 6");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game7"))
        {
            SceneManager.LoadScene("Game 7");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game8"))
        {
            SceneManager.LoadScene("Game 8");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game9"))
        {
            SceneManager.LoadScene("Game 9");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }
        else if (round.Equals("Game10"))
        {
            SceneManager.LoadScene("Game 10");
            item = 0;
            PlayerPrefs.SetInt("Item", item);
        }

    }
}
