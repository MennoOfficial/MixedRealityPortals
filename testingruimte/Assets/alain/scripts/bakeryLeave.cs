using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class bakeryLeave : TeleportationArea
{
    private FadeCanvas fadeCanvas = null;
    private GameObject player;
    private GameObject bakkersTv;

    protected override void Awake()
    {
        base.Awake();
        fadeCanvas = FindObjectOfType<FadeCanvas>();
        player = GameObject.FindWithTag("speler");
        bakkersTv = GameObject.FindWithTag("bakkerstv");
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (teleportTrigger == TeleportTrigger.OnSelectEntered)
            StartCoroutine(FadeSequence(base.OnSelectEntered, args));
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnSelectExited)
            StartCoroutine(FadeSequence(base.OnSelectExited, args));
        player.gameObject.transform.position = new Vector3(-43f, 1f, 45f);
        player.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        Debug.Log("BYE");
        PlayVideo bakkersfilm = bakkersTv.GetComponent<PlayVideo>();
        bakkersfilm.Stop();
    }

    protected override void OnActivated(ActivateEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnActivated)
            StartCoroutine(FadeSequence(base.OnActivated, args));
    }

    protected override void OnDeactivated(DeactivateEventArgs args)
    {
        if (teleportTrigger == TeleportTrigger.OnDeactivated)
            StartCoroutine(FadeSequence(base.OnDeactivated, args));
    }

    private IEnumerator FadeSequence<T>(UnityAction<T> action, T args)
        where T : BaseInteractionEventArgs
    {
        fadeCanvas.QuickFadeIn();

        yield return fadeCanvas.CurrentRoutine;
        action.Invoke(args);

        fadeCanvas.QuickFadeOut();
    }
}
