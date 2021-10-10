using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject scoreText;

    private int playerScore = 0;

    public void IncreaseScore(int killValue)
    {
        playerScore += killValue;
        scoreText.GetComponent<TextMeshProUGUI>().text = $"HIGHSCORE: {playerScore}";
    }
}
