using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Situp : Task
{
    private float failRate = 40f;
    private float successAmount = 35f;
    private int countLimit = 2;

    private float weightAmount = 15f;

    public override void DoTask() {
        StartCoroutine(DoTaskCoroutine());
    }

    private void DoExercise() {
        PlayerStatus playerStatus = FindAnyObjectByType<PlayerStatus>();
        
        if (count > countLimit && UnityEngine.Random.Range(0f, 100f) > 20) {
            playerStatus.Die("you burned so much fat you set yourself on fire");
        }

        if (UnityEngine.Random.Range(0f, 100f) > failRate) {
            playerStatus.cholesterolValue -= successAmount;
            playerStatus.weightValue -= weightAmount;
            count++;
        } else {
            playerStatus.Die("you were unable to get up and starved to death");
        }
    }

    IEnumerator DoTaskCoroutine() {
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        Menu menu = FindAnyObjectByType<Menu>();

        playerInput.DeactivateInput();
        fadeHandler.FadeOut();
        yield return new WaitForSecondsRealtime(0.7f);
        DoExercise();
        menu.OnCancel();
        playerInput.ActivateInput();
    }
}
