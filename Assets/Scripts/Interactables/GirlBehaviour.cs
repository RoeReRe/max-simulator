using System;
using UnityEngine;

public class GirlBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Please let me go I promise not to tell anyone."
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Girl: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
