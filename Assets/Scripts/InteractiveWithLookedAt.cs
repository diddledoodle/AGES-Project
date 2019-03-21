using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an iInteractive,
/// and then calls that IInteractive's InteractWith method.
/// </summary>
public class InteractiveWithLookedAt : MonoBehaviour
{
    private IInteractive lookedatInteractive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedatInteractive !=null)
        {
            Debug.Log("Player pressed the Interact button.)");
            lookedatInteractive.InteractWith();
            
        }
    }

    private void OnLookedAtInteractiveChanged(IInteractive newLookedatInteractive)
    {
        lookedatInteractive = newLookedatInteractive;
    }
    /// <summary>
    /// event handler for DetectLookedatInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedatInteractive">Reference for the new interactive the player is looking at.</param>
    #region event subscription / unsubscription
    private void OnEnable()
    {
        DetectLookedatInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }
    private void OnDisable()
    {
        DetectLookedatInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion
}
