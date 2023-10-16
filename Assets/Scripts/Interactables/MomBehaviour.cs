using System;
using UnityEngine;

public class MomBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Fuck off.",
        "Stop walking around like a toad.",
        "Can you go away?",
        "Where is my dinner?",
        "Gargle my ballsack.",
        "Eventually, probably soon, the world will recognize you for the pitiful disappointment you are. You are not worthy of my respect. You are not a god. You are simply bad product."
    };

    public void Interact() {
        messageHandler.SetText(String.Format("Mom: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
