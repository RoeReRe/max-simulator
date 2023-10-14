using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeHandler : MonoBehaviour
{
    PlayerMovement playerMovement;
    Animator fadeAnimator;

    private void Awake() {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        fadeAnimator = GetComponent<Animator>();
    }

    public void FadeOut() {
        fadeAnimator.SetTrigger("fade");
    }
}
