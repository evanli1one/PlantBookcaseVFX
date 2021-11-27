using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Events;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] private VisualEffect effect;

    [SerializeField] bool loop;
    [SerializeField] float startDelay;
    [SerializeField] float endDelay;

    private UnityEvent onEffectPlay = new UnityEvent();

    public void Construct()
    {
        if (effect == null)
        {
            Debug.LogError(this + " Error: effect cannot be null");
        }

        if (loop)
        {
            onEffectPlay.AddListener(StartLoopEffect);
        }
        else
        {
            onEffectPlay.AddListener(StartPlayEffect);
        }
    }

    public void StartEffectPlayer()
    {
        onEffectPlay.Invoke();
    }

    private void StartLoopEffect()
    {
        StartCoroutine(LoopEffect());
    }

    private void StartPlayEffect()
    {
        StartCoroutine(PlayEffect());
    }

    private IEnumerator LoopEffect()
    {
        while (true)
        {
            yield return new WaitForSeconds(startDelay);
            effect.Play();
            yield return new WaitForSeconds(endDelay);
        }
    }

    private IEnumerator PlayEffect()
    {
        yield return new WaitForSeconds(startDelay);
        effect.Play();
    }
}
