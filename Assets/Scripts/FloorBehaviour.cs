using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorBehaviour : MonoBehaviour
{
    [SerializeField] MessageHandler messageHandler;
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] ParticleSystem smoke;
    [NonSerialized] public float maxIntegrity = 20f;
    [NonSerialized] public float integrity = 20f;
    private float multiplier = 1f;
    private int tetrisCount = 0;
    private float tetrisProbability = 50f;

    private void Awake() {
        if (!StaticUtil.isDead) {
            InvokeRepeating("StartTetris", 30f, 60f);
        }
    }
    
    private void Update() {
        if (integrity <= 0 && !playerStatus.isDead) {
            Instantiate(smoke, playerStatus.transform.position, smoke.transform.rotation);
            GetComponent<AudioSource>().Play();
            playerStatus.Die("You crashed through the floor.");
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player") && other.GetComponent<Rigidbody2D>().velocity.magnitude > Mathf.Epsilon) {
            integrity -= multiplier * Time.deltaTime;
        }
    }

    public void ResetParams() {
        integrity = maxIntegrity;
    }

    public void StartTetris() {
        if (playerStatus.isDead) {
            return;
        }
        
        if (UnityEngine.Random.Range(0, 100) > 100 - tetrisProbability - tetrisCount * 15) {
            StartCoroutine(StartTetrisCoroutine());
        }
    }

    IEnumerator StartTetrisCoroutine() {
        messageHandler.SetText("You feel your chest tighten...");
        yield return new WaitForSecondsRealtime(3f);
        StaticUtil.lastPosition = playerStatus.transform.position;
        StaticUtil.lastCholesterol = playerStatus.cholesterolValue;
        StaticUtil.lastWeight = playerStatus.weightValue;
        StaticUtil.isInvoked = true;
        SceneManager.LoadScene("Tetris");
    }
}
