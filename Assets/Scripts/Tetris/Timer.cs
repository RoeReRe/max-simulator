using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeRemaining = 18;
    [SerializeField] TMP_Text timeText;
    [NonSerialized] public bool timerIsRunning = false;

    private void Start() {
        timerIsRunning = true;
    }

    private void Update() {
        if (timerIsRunning) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
            }
            else {
                timeRemaining = 0;
                timerIsRunning = false;
                FindObjectOfType<Board>().GameEnd();
            }
            DisplayTime(timeRemaining);
        }
    }

    private void DisplayTime(float timeToDisplay) {
        float seconds = Mathf.FloorToInt(timeToDisplay);
        float milliseconds = Mathf.FloorToInt((timeToDisplay - seconds) * 60);
        timeText.text = string.Format("UNCLOG YOUR ARTERIES\n{0:00}:{1:00}", seconds, milliseconds);
    }
}