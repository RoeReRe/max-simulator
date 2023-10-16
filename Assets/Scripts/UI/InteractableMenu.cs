using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class InteractableMenu : MonoBehaviour
{
    PlayerMovement playerMovement;
    [SerializeField] Button buttonPrefab;

    private void Start() {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnEnable() {
        GetComponentInChildren<Button>().Select();
    }

    private void OnDisable() {
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
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

    public void setInterface(Dictionary<String, Action> buttonMapping) {
        Button prev = null;
        foreach (KeyValuePair<String, Action> kv in buttonMapping) {
            Button tmp = Instantiate(buttonPrefab, this.transform);
            tmp.GetComponentInChildren<TMP_Text>().text = kv.Key;
            tmp.onClick.AddListener(() => kv.Value.Invoke());

            if (prev != null) {
                Navigation tmpNav = prev.navigation;
                tmpNav.mode = Navigation.Mode.Explicit;
                tmpNav.selectOnDown = tmp;
                prev.navigation = tmpNav;

                tmpNav = tmp.navigation;
                tmpNav.mode = Navigation.Mode.Explicit;
                tmpNav.selectOnUp = prev;
                tmp.navigation = tmpNav;
            }
            prev = tmp;
        }
        this.gameObject.SetActive(true);
    }
}
