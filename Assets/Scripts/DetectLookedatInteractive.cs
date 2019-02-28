﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// it detects interactive elements the player is looking at.
/// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
/// </summary>

public class DetectLookedatInteractive : MonoBehaviour
{
   
    [Tooltip("Starting point of raycast used to detect interactives.")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycastOrigin will search for the interactive elements.")]
    [SerializeField]
    private float maxRange = 5.0f;


    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position,raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        if (objectWasDetected)
        {
            Debug.Log("Player is looking at:" + (hitInfo.collider.gameObject.name) );
        } 
    }

}
