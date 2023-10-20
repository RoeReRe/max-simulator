using System;
using UnityEngine;

public class KitchenBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Its full of ants.",
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Max: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
