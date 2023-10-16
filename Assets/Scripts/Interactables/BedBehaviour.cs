using System;
using UnityEngine;

public class BedBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;

    public void Interact() {
        messageHandler.SetText(String.Format("Max: I have masturbated here {0} times.", UnityEngine.Random.Range(326785, 100000000)));
    }
}
