using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComputerBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] InteractableMenu interactableMenu;

    Dictionary<String, Action> buttonMapping;

    public void Interact() {
        buttonMapping = new Dictionary<string, Action>() {
            {"476986", () => Death()},
            {"169134", () => Death()},
            {"402961", () => Death()},
        };
        interactableMenu.setInterface(buttonMapping);
    }

    public void Death() {
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine() {
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        fadeHandler.FadeOut();
        yield return new WaitForSecondsRealtime(0.7f);
        FindAnyObjectByType<PlayerStatus>().Die("you watched something that was too repulsive");
        interactableMenu.OnCancel();
    }
}
