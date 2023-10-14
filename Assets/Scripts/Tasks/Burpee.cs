using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Burpee : Task
{
    private float failRate = 50f;
    private float successAmount = 50f;
    private int countLimit = 2;

    private float weightAmount = 25f;

    public override void DoTask() {
        StartCoroutine(DoTaskCoroutine());
    }

    private void DoExercise() {
        PlayerStatus playerStatus = FindAnyObjectByType<PlayerStatus>();
        
        if (count > countLimit && UnityEngine.Random.Range(0f, 100f) > 20) {
            playerStatus.Die("you jumped too much and crashed through the floor");
        }

        if (UnityEngine.Random.Range(0f, 100f) > failRate) {
            playerStatus.cholesterolValue -= successAmount;
            playerStatus.weightValue -= weightAmount;
            count++;
        } else {
            playerStatus.Die("you caused the first earthquake in Singapore");
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
