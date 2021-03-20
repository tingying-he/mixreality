using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnNextTracked : MonoBehaviour
{
    public AudioClip nextAppearClip;
    public AudioClip nextMatchClip;
    public AudioClip completeClip;

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.enabled = false;
    }

    public void Initialize()
    {
        source.enabled = true;
    }

    public void PlayOnAppear()
    {
        source.clip = nextAppearClip;
        source.Play();
    }

    public void PlayOnMatch()
    {
        source.clip = nextMatchClip;
        source.Play();
    }

    public void PlayOnComplete()
    {
        source.clip = completeClip;
        source.Play();
    }
}
