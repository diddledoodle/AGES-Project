using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : InteractiveObject
{
    [Tooltip("This is a seperate audio clip that will play when player interacts with a specific object, such as an alarm.")]
    [SerializeField]
    private AudioClip itemClip;
    [Tooltip("This bool means the sound is not currently playing.")]
    [SerializeField]
    private bool isPlayed;
    [Tooltip("This bool means the sound is currently playing.")]
    [SerializeField]
    private bool isPlaying;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = itemClip;
    }
    private void Update()
    {
        isPlaying = audioSource.isPlaying;
    }
    public override void InteractWith()
    {
        base.InteractWith();
        if (isPlayed)
        {
            audioSource.Play();
        }
        if (!isPlayed)
        {
            audioSource.Stop();
        }
        if (isPlaying)
        {
            audioSource.Stop();
        }
    }
}