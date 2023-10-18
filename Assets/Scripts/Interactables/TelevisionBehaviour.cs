using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TelevisionBehaviour : MonoBehaviour, Interactable
{
    [SerializeField] MessageHandler messageHandler;
    [SerializeField] InteractableMenu interactableMenu;
    [SerializeField] Volume globalVolume;

    Dictionary<String, Action> buttonMapping;

    public void Interact() {
        buttonMapping = new Dictionary<string, Action>() {
            {"JAV", () => JAV()},
            {"The Lighthouse", () => Lighthouse()},
            {"The Boys", () => TheBoys()},
        };
        interactableMenu.setInterface(buttonMapping);
    }

    public void JAV() {
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine() {
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        fadeHandler.FadeOut();
        interactableMenu.OnCancel();
        yield return new WaitForSecondsRealtime(0.7f);
        FindAnyObjectByType<PlayerStatus>().Die("depression");
    }

    public void Lighthouse() {
        StartCoroutine(LighthouseCoroutine());
    }

    IEnumerator LighthouseCoroutine() {
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        fadeHandler.FadeOut();
        interactableMenu.OnCancel();
        GetComponent<AudioSource>().Play();
        yield return new WaitForSecondsRealtime(0.7f);

        VolumeParameter<float> saturationShift = new();
        saturationShift.value = -100f;
        ColorAdjustments colorAdjustments;
        globalVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        colorAdjustments.saturation.SetValue(saturationShift);
    }

    public void TheBoys() {
        StartCoroutine(TheBoysCoroutine());
    }

    IEnumerator TheBoysCoroutine() {
        FadeHandler fadeHandler = FindAnyObjectByType<FadeHandler>();
        fadeHandler.FadeOut();
        interactableMenu.OnCancel();
        yield return new WaitForSecondsRealtime(0.7f);

        messageHandler.SetText("Homelander: I can see your girdle you disgusting fat fuck.");
    }
}
