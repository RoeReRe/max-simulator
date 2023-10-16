using System;
using UnityEngine;

public class WardrobeBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Its all XXXL.",
        "Its all torn white shirts.",
        "I'm only keeping these torn shirts as a running gag.",
        "I hope no one finds the cosplay I'm hiding here."
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Max: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
