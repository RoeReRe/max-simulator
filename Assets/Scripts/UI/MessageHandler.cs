using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class MessageHandler : MonoBehaviour
{
    [SerializeField] TMP_Text msgText;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            OnCancel();
        }
    }

    public void SetText(string msg) {
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("UI");
        msgText.text = msg;
        msgText.maxVisibleCharacters = 0;
        this.gameObject.SetActive(true);
    }

    private void OnEnable() {
        StartCoroutine(DisplayText());
    }

    IEnumerator DisplayText() {
        while (msgText.maxVisibleCharacters < msgText.text.Length) {
            msgText.maxVisibleCharacters++;
            yield return new WaitForSecondsRealtime(0.03f);
        }
    }

    public void OnCancel() {
        this.gameObject.SetActive(false);
        FindObjectOfType<PlayerInput>().SwitchCurrentActionMap("Player");
    }
}
