using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveGameTimer : MonoBehaviour
{
    [SerializeField] Minefield minefield;
    [SerializeField] Text timer;

    float timeSinceStart = 0;
    bool isStopped = true;

    private void OnGameStartedCallback()
    {
        isStopped = false;
        timer.gameObject.SetActive(true);
    }

    private void OnGameFinishedCallback(bool isWin)
    {
        isStopped = true;
        timeSinceStart = 0;
        timer.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isStopped)
        {
            timeSinceStart += Time.deltaTime;
            timer.text = timeSinceStart.ToString("#");
        }
    }

    private void OnEnable()
    {
        minefield.OnGameStarted += OnGameStartedCallback;
        minefield.OnGameFinished += OnGameFinishedCallback;
    }

    private void OnDisable()
    {
        minefield.OnGameStarted -= OnGameStartedCallback;
        minefield.OnGameFinished -= OnGameFinishedCallback;
    }
}
