using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public GameObject PauseText;
    public GameObject ResultsText;
    public static bool GameIsPaused = true;
    public static bool GameIsOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && !GameIsOver)
        {
            PauseGame();
        }

        if (Input.GetKeyUp(KeyCode.Space) && GameIsOver)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        GameIsPaused = !GameIsPaused;

        if (!GameIsPaused)
        {
            Debug.Log("Game is Over!");
            Time.timeScale = 0f;
            GameIsOver = true;
            ResultsText.SetActive(true);
        }
        else
        {
            Debug.Log("Rematch!");
            Time.timeScale = 1f;
            GameIsOver = false;
            ResultsText.SetActive(false);
        }
    }

    public void PauseGame()
    {
        GameIsPaused = !GameIsPaused;

        if (!GameIsPaused)
        {
            Debug.Log("Pausing game...");
            Time.timeScale = 0f;
            PauseText.SetActive(true);
        }
        else
        {
            Debug.Log("Unpausing game...");
            Time.timeScale = 1f;
            PauseText.SetActive(false);
        }
    }
}
