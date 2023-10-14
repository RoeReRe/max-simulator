using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorBehaviour : MonoBehaviour
{
    PlayerStatus playerStatus;
    CompositeCollider2D compositeCollider;
    [SerializeField] MessageHandler messageHandler;

    private void Start() {
        playerStatus = FindAnyObjectByType<PlayerStatus>();
        compositeCollider = GetComponent<CompositeCollider2D>();

        if (playerStatus.weightValue >= playerStatus.weightThreshold) {
            compositeCollider.isTrigger = false;
        }
    }

    private void Update() {
        if (playerStatus.weightValue < playerStatus.weightThreshold) {
            compositeCollider.isTrigger = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        messageHandler.SetText("You can't fit through the door.");
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (playerStatus.weightValue >= playerStatus.weightThreshold) {
            compositeCollider.isTrigger = false;
        }
    }
}
