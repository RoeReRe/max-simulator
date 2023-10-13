using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] Slider cholesterolSlider;
    [SerializeField] TMP_Text cholesterolText;
    [SerializeField] Slider weightSlider;

    [NonSerialized] public float cholesterolValue = 65f;
    [NonSerialized] public float weightValue = 85f;
    [NonSerialized] public float maxCholesterol = 100f;
    [NonSerialized] public float maxWeight = 150f;
    [NonSerialized] public float cholesterolThreshold = 70f;

    [SerializeField] float cholesterolSpeed = 0.8f;
    [SerializeField] float weightSpeed = 0.2f;

    [NonSerialized] public bool isDead;

    private void Update() {
        UpdateSliders();
        if (cholesterolValue > 75f) {
            isDead = true;
        }
    }

    private void UpdateSliders() {
        cholesterolValue = Mathf.Clamp(cholesterolValue + cholesterolSpeed * Time.deltaTime, 0f, maxCholesterol);
        weightValue = Mathf.Clamp(weightValue + weightSpeed * Time.deltaTime, 0f, maxWeight);

        cholesterolSlider.value = cholesterolValue / maxCholesterol;
        weightSlider.value = weightValue / maxWeight;

        cholesterolText.color = cholesterolValue >= cholesterolThreshold ? new Color(1f, 0.3764706f, 0.3764706f, 1f) : new Color(1f, 1f, 1f, 1f);
    }
}
