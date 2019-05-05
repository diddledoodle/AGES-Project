using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The Gameobject to toggle.")]
    [SerializeField]
    private GameObject objecttoToggle;

    [Tooltip("Can the player interact with this more than once?")]
    [SerializeField]
    private bool isReusable = true;
    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objecttoToggle when the player interacts with this object.
    /// </summary>
    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            objecttoToggle.SetActive(!objecttoToggle.activeSelf);
            hasBeenUsed = true;
            if (!isReusable) displayText = string.Empty;
        }
    }
}
