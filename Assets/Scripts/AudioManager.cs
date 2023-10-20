using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource bgm;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        bgm = GetComponent<AudioSource>();
    }

    public void Play() {
        bgm.Play();
    }

    public void Stop() {
        bgm.Stop();
    }
}
