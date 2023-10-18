using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Scene = UnityEngine.SceneManagement.Scene;

public class DeathHandler : MonoBehaviour
{
    private CinemachineVirtualCamera followCamera;
    private TMP_Text deathMessage;
    private float orthoSize;
    
    private void Awake() {
        followCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        deathMessage = GetComponentInChildren<TMP_Text>();
        GetComponentInChildren<Button>().Select();
        orthoSize = followCamera.m_Lens.OrthographicSize;
    }

    private void Start() {
        GetComponent<AudioSource>().Play();
    }

    private void Update() {
        followCamera.m_Lens.OrthographicSize = Mathf.Clamp(followCamera.m_Lens.OrthographicSize - 0.01f, 3.5f, 6.5f);
    }

    public void SetDeathMessage(string text) {
        deathMessage.text = "You died\nCause of death: " + text;
    }

    public void StartOver() {
        StartCoroutine(StartOverCoroutine());
    }

    IEnumerator StartOverCoroutine() {
        yield return new WaitForSecondsRealtime(0.3f);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
