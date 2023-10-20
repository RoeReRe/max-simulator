using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Phone : Task
{
    [SerializeField] MessageHandler messageHandler;

    private String[] dialogue = {
        "Time to cancel my plans with Jasmon, Dylan and WX again.",
        "What excuse should I use to tell them I can't make it again? Or maybe I just don't give a reason.",
        "I'm actually just lazy to meet them, but I'll just tell them I have duty."
    };

    public override void DoTask() {
        Menu menu = FindAnyObjectByType<Menu>();
        menu.OnCancel();
        messageHandler.SetText(String.Format("Max: {0}", dialogue[UnityEngine.Random.Range(0, dialogue.Length)]));
    }
}
