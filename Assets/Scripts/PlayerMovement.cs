using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    [SerializeField] float moveSpeed = 10f;

    Rigidbody2D playerRigidBody;
    Animator playerAnimator;
    PlayerStatus playerStatus;
    [SerializeField] Menu menu;

    [SerializeField] GameObject uiCanvas;
    [SerializeField] GameObject deathScreen;
    [NonSerialized] bool isOnDeathScreen = false;
    [NonSerialized] public string deathMessage = "Unknown";

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerStatus = GetComponent<PlayerStatus>();
    }

    private void Update() {
        Walk();
        SetSprite();
        CheckStatus();
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

    private void Walk() {
        playerRigidBody.velocity = moveInput * new Vector2(moveSpeed, moveSpeed);
        playerAnimator.SetBool("isWalking", Mathf.Abs(playerRigidBody.velocity.magnitude) > Mathf.Epsilon);
        playerStatus.isCholesterolChanging = !(Mathf.Abs(playerRigidBody.velocity.magnitude) > Mathf.Epsilon); 
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
            GetComponent<PlayerInput>().DeactivateInput();
        }
    }
}
