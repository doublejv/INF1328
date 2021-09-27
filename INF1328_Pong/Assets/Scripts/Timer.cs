using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float TimeValue = 90.0f;
    public GameObject TimerText;
    public GameObject GameManager;

    private float defaultTimeValue;

    // Start is called before the first frame update
    void Start()
    {
        defaultTimeValue = TimeValue;
        TimeValue = defaultTimeValue + 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeValue > 0)
        {
            TimeValue -= Time.deltaTime;
        }
        else
        {
            GameManager.GetComponent<GameManager>().RestartGame();
            ResetTime();
        }

        DisplayTime(TimeValue);
    }

    public void ResetTime()
    {
        Debug.Log("Resetting Timer...");
        TimeValue = defaultTimeValue;
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = timeToDisplay % 1 * 1000;

        TimerText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
