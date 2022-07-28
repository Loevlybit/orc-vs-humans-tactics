using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] Minefield minefield;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject endGamePanel;
    [SerializeField] Text resultText;

    private void OnEnable()
    {
        minefield.OnGameFinished += OnGameFinishedCallback;
    }

    private void OnDisable()
    {
        minefield.OnGameFinished -= OnGameFinishedCallback;
    }

    private void OnGameFinishedCallback(bool isWin)
    {
        if (isWin)
        {
            resultText.text = "You win!";
        }
        else
        {
            resultText.text = "You lose";
        }
        endGamePanel.SetActive(true);
    }

    public void StartGame()
    {
        minefield.StartGame();
        mainMenu.SetActive(false);
        endGamePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        endGamePanel.SetActive(false);
    }
}
