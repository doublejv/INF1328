using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball")]
    public GameObject Ball;

    [Header("Player1")]
    public GameObject Player1Paddle;
    public GameObject Player1Goal;

    [Header("Player2")]
    public GameObject Player2Paddle;
    public GameObject Player2Goal;

    [Header("Score UI")]
    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject ResultsText;

    [Header("Controllers")]
    public GameObject TimeController;
    public GameObject PauseController;

    private int Player1Score;
    private int Player2Score;

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
    }

    public void Player1Scored()
    {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ResetPosition();
    }

    public void Player2Scored()
    {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ResetPosition();
    }

    public void RestartGame()
    {
        ResetPosition();
        PauseController.GetComponent<PauseControl>().RestartGame();
        ResultsText.GetComponent<TextMeshProUGUI>().text = $"\t\tResults\t\t   \n{Player1Score.ToString()}\t\t\t\t{Player2Score.ToString()}"; 

        Player1Score = 0;
        Player2Score = 0;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
    }

    private void ResetPosition()
    {
        Ball.GetComponent<Ball>().Reset();
        Player1Paddle.GetComponent<Player>().Reset();
        Player2Paddle.GetComponent<Player>().Reset();
    }

    private void SetupGame()
    {
        Ball.SetActive(true);
        PauseController.GetComponent<PauseControl>().PauseGame();
    }
}
