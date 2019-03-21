using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// this UI text displays info about the currently looked at interactive iinteractive.
/// the text should be hidden if the player is not currently looking at an interactive element.
/// </summary>

public class LookedAtInteractiveDispalyText : MonoBehaviour
{
    private IInteractive lookedatInteractive;
    private Text displayText;

    private void Awake()
    {
        displayText = GetComponent<Text>();
        UpdateDisplayText();
    }

    private void UpdateDisplayText()
    {
        if (lookedatInteractive != null)
            displayText.text = lookedatInteractive.DisplayText;

        else
            displayText.text = string.Empty;

    }
    /// <summary>
    /// event handler for DetectLookedatInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedatInteractive">Reference for the new interactive the player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedatInteractive)
    {
        lookedatInteractive = newLookedatInteractive;
        UpdateDisplayText();
    }
    #region Event subscription / unsubscription
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
