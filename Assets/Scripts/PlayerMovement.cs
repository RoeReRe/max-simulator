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

    private void Start() {
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Walk();
        SetSpriteOrientation();
    }

    void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

    private void Walk() {
        playerRigidBody.velocity = moveInput * new Vector2(moveSpeed, moveSpeed);
    }

    private void SetSpriteOrientation() {
        if (Mathf.Abs(playerRigidBody.velocity.x) > Mathf.Epsilon) {
            transform.localScale = new Vector2(Mathf.Sign(playerRigidBody.velocity.x), 1f);
        }
    }
}
