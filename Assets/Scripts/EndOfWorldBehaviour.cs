using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfWorldBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            GetComponent<AudioSource>().Play();
            Instantiate(smoke, other.gameObject.GetComponent<PlayerStatus>().transform.position, smoke.transform.rotation);
            other.gameObject.GetComponent<PlayerStatus>().Die("I didn't code this part. Go back to your house");
        }
    }
}
