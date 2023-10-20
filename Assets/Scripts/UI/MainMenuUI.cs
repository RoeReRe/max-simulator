using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] GameObject mainScreen;
    [SerializeField] GameObject difficultyScreen;
    [SerializeField] GameObject controlScreen;

    [SerializeField] TMP_Text difficultyText;

    private bool isMain = true;
    
    private void Start() {
        mainScreen.SetActive(true);
        difficultyScreen.SetActive(false);
        controlScreen.SetActive(false);
    }

    private void Update() {
        if (IsAnyKey() && isMain) {
            isMain = false;
            mainScreen.SetActive(false);
            difficultyScreen.SetActive(true);
        } 
    }

    private bool IsAnyKey() {
        if (Input.anyKeyDown) {
            if (Input.GetMouseButtonDown(0) 
                || Input.GetMouseButtonDown(1)
                || Input.GetMouseButtonDown(2)) {
                    return false;
                }
            return true;
        }
        return false;
    }

    public void OnSliderValue() {
        Slider slider = GetComponentInChildren<Slider>();
        int weight = Mathf.Clamp(Mathf.FloorToInt(slider.value * (150 - 85) + 85), 85, 150);
        difficultyText.text = String.Format("Weight: {0} KG", weight);
    }

    public void OnDifficultyStart() {
        difficultyScreen.SetActive(false);
        controlScreen.SetActive(true);
    }

    public void OnControlStart() {
        SceneManager.LoadScene("Main");
    }
}
