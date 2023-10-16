using System;
using UnityEngine;

public class ToiletBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Smells like shit.",
        "I still remember the time when Jasmon broke the vase in the toilet...",
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Max: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
