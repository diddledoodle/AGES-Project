using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    [Tooltip("Assigning a key here will lock the door. If the player has a key in their inventory, they can open the locked door.")]
    [SerializeField]
    private InventoryObject key;
    [Tooltip("If this is checked, the associated key will be removed from the player's inventory when the door is unlocked.")]
    [SerializeField]
    private bool consumesKey;
    [Tooltip("The text that displays when the player looks at the door while it's locked.")]
    [SerializeField]
    private string lockedDisplayText = "Locked";
    [Tooltip("Play this audio when the player interacts with a locked door.")]
    [SerializeField]
    private AudioClip lockedAudioClip;
    [Tooltip("Play this audio when the player opens the door.")]
    [SerializeField]
    private AudioClip openAudioClip;

    private bool HasKey => PlayerInventory.InventoryObjects.Contains(key);
    private bool isLocked = false;
    private Animator animator;
    private bool isOpen = false;
    private int shouldOpen = Animator.StringToHash(nameof(shouldOpen));
    public override string DisplayText
    {
        get
        {
            string toReturn;
            
            if (isLocked)
                toReturn = HasKey? $"Use {key.ObjectName}" : lockedDisplayText;
            else
                toReturn = base.DisplayText;
            return toReturn;
        }
    }
    /// <summary>
    /// Using a constructor here to intialize displayText in the editor.
    /// </summary>
    public Door()
    {
        displayText = nameof(Door);
    }
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
        InitializeisLocked();
    }
    private void InitializeisLocked()
    {
        if (key != null)
            isLocked = true;
    }
    public override void InteractWith()
    {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        if (!isOpen)
        {
            if(isLocked && !HasKey)
            {
                audioSource.clip = lockedAudioClip;
            }
            else // if its not locked or if its locked and we have the key
            {
                audioSource.clip = openAudioClip;
                animator.SetBool(shouldOpen, true);
                displayText = string.Empty;
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith();//this plays a sound effect!
        }
    }
    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
            PlayerInventory.InventoryObjects.Remove(key);
    }
}
