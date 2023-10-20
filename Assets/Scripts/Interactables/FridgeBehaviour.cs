using System;
using UnityEngine;

public class FridgeBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "This is expired, maybe I'll use and cook it for when they come visit on 23 Oct.",
        "Time to make some hand-squeezed bone broth.",
        "I forgot I left a jar of semen inside.",
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Max: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
