using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxFollow : MonoBehaviour
{
    private Vector2 relativePost;

    private void Awake() {
        relativePost = this.transform.localPosition;
    }

    private void Update() {
        this.transform.localPosition = relativePost;
    }
}
