using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ComputerBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] InteractableMenu interactableMenu;

    Dictionary<String, Action> buttonMapping;

    public void Interact() {
        buttonMapping = new Dictionary<string, Action>() {
            {"A", () => DummyAction()},
            {"B", () => DummyAction()},
            {"C", () => DummyAction()},
        };
        interactableMenu.setInterface(buttonMapping);
    }

    public void DummyAction() {
        interactableMenu.OnCancel();
    }
}
