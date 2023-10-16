using System;
using UnityEngine;

public class BedsideWardrobeBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Hope no one finds that heinous shit I've been hiding.",
        "My Tenga is missing."
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Max: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
