using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TelevisionBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] InteractableMenu interactableMenu;

    Dictionary<String, Action> buttonMapping;

    public void Interact() {
        buttonMapping = new Dictionary<string, Action>() {
            {"JAV", () => JAV()},
            {"The Lighthouse", () => {}},
            {"The Boys", () => {}},
            {"American Psycho", () => {}}
        };
        interactableMenu.setInterface(buttonMapping);
    }

    public void JAV() {
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine() {
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        fadeHandler.FadeOut();
        yield return new WaitForSecondsRealtime(0.7f);
        FindAnyObjectByType<PlayerStatus>().Die("depression");
        interactableMenu.OnCancel();
    }
}
