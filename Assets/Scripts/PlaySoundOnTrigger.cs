using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : InteractiveObject
{

    [Tooltip("This is a seperate audio clip that will play when player interacts with a specific object, such as an alarm.")]
    [SerializeField]
    private AudioClip itemClip;
    [SerializeField]
    private bool isPlayed;
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
