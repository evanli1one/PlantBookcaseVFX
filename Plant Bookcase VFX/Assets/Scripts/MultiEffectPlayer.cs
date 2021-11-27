using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UI;

public class MultiEffectPlayer : MonoBehaviour
{
    [SerializeField] private List<EffectPlayer> effectPlayerList = new List<EffectPlayer>();
    [SerializeField] private List<Animator> animatorList = new List<Animator>();
    [SerializeField] private List<PlayableDirector> playableDirectorList = new List<PlayableDirector>();

    [SerializeField] private GameObject playButtonObject;
    [SerializeField] private float effectDuration;
    [SerializeField] private bool loop;

    private void Awake()
    {
        foreach (EffectPlayer effect in effectPlayerList)
        {
            effect.Construct();
        }
        foreach (Animator animator in animatorList)
        {
            animator.enabled = false;
        }
    }

    public void StartPlayEffects()
    {
        StartCoroutine(PlayEffects());
    }

    private IEnumerator PlayEffects()
    {
        playButtonObject.SetActive(false);

        foreach (EffectPlayer effect in effectPlayerList)
        {
            effect.StartEffectPlayer();
        }
        foreach (Animator animator in animatorList)
        {
            animator.enabled = true;
            animator.Play("Base Layer.Effect", -1, 0f);
        }
        foreach (PlayableDirector playable in playableDirectorList)
        {
            playable.Play();
        }

        yield return new WaitForSeconds(effectDuration);

        if(loop)
        {
            StartCoroutine(PlayEffects());
        }
        else
        {
            playButtonObject.SetActive(true);
        }
    }
}
