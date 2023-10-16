using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    [SerializeField] PlayerStatus playerStatus;
    [SerializeField] ParticleSystem smoke;
    public float maxIntegrity = 30f;
    public float integrity = 30f;
    private float multiplier = 1f;

    private void Update() {
        if (integrity <= 0 && !playerStatus.isDead) {
            Instantiate(smoke, playerStatus.transform.position, smoke.transform.rotation);
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
}
