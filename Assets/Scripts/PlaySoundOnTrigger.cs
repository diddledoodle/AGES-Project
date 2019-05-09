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

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = itemClip;
        isPlayed = false;
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
    }
}
