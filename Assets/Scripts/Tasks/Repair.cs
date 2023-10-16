using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Repair : Task
{
    private float failRate = 5f;
    private float successAmount = 3f;
    private float weightAmount = 3f;

    public override void DoTask() {
        StartCoroutine(DoTaskCoroutine());
    }

    private void DoRepair() {
        PlayerStatus playerStatus = FindAnyObjectByType<PlayerStatus>();
        FloorBehaviour floorBehaviour = FindAnyObjectByType<FloorBehaviour>();
        
        if (UnityEngine.Random.Range(0f, 100f) > failRate * Mathf.Max(1, count)) {
            playerStatus.cholesterolValue -= successAmount;
            playerStatus.weightValue -= weightAmount;
            count++;
            floorBehaviour.integrity = floorBehaviour.maxIntegrity;
        } else {
            playerStatus.Die("your arteries ruptured during a push up");
        }
    }

    IEnumerator DoTaskCoroutine() {
        PlayerInput playerInput = FindAnyObjectByType<PlayerInput>();
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        Menu menu = FindAnyObjectByType<Menu>();

        playerInput.DeactivateInput();
        fadeHandler.FadeOut();
        yield return new WaitForSecondsRealtime(0.7f);
        DoRepair();
        menu.OnCancel();
        playerInput.ActivateInput();
    }
}
