using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 10f;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    PlayerStatus playerStatus;
    [SerializeField] Menu menu;
    [SerializeField] FloorBehaviour floor;

    [SerializeField] GameObject uiCanvas;
    [SerializeField] GameObject deathScreen;
    [NonSerialized] bool isOnDeathScreen = false;
    [NonSerialized] public string deathMessage = "Unknown";

    private GameObject lastContact;

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerStatus = GetComponent<PlayerStatus>();
        lastContact = this.gameObject;
    }

    private void Update() {
        Walk();
        SetSprite();
        CheckStatus();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Interactable")) {
            lastContact = other.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Interactable")) {
            lastContact = this.gameObject;
        }
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    void OnMenu() {
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu() {
        yield return new WaitForSecondsRealtime(0.1f);
        menu.gameObject.SetActive(true);
        GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
    }

    void OnInteract() {
        StartCoroutine(Interact());
    }

    IEnumerator Interact() {
        if (!lastContact.CompareTag("Interactable")) {
            yield break;
        }
        GameObject cachedContact = lastContact;
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        cachedContact.GetComponent<Interactable>().Interact();
    }

    private void Walk() {
        bool isWalking = Mathf.Abs(playerRigidBody.velocity.magnitude) > Mathf.Epsilon;

        playerRigidBody.velocity = moveInput * new Vector2(moveSpeed, moveSpeed);
        playerAnimator.SetBool("isWalking", isWalking);
        playerStatus.isCholesterolChanging = !isWalking;
    }

    private void SetSprite() {
        if (Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }

    private void CheckStatus() {
        if (playerStatus.isDead && !isOnDeathScreen) {
            isOnDeathScreen = true;
            playerAnimator.SetTrigger("isDead");
            DeathHandler deathHandler = Instantiate(deathScreen, uiCanvas.transform).GetComponent<DeathHandler>();
            deathHandler.SetDeathMessage(deathMessage);
            menu.ResetParams();
            floor.ResetParams();
            // rmb to update isdead and isondeath
            GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
        }
    }
}
