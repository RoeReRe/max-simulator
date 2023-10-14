using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start() {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnEnable() {
        GetComponentInChildren<Button>().Select();
    }

    private void OnDisable() {
        GetComponentInChildren<Button>().Select();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnCancel();
        }
    }

    public void OnCancel() {
        this.gameObject.SetActive(false);
        playerMovement.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
    }

    public void ResetParams() {
        Task[] taskList = GetComponentsInChildren<Task>();
        foreach (Task task in taskList) {
            task.count = 0;
        }
    }
}
