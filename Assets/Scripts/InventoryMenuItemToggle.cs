using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenuItemToggle : MonoBehaviour
{
    [Tooltip("The image component used to show the object's icon.")]
    [SerializeField]
    private Image iconImage;
    public static event Action<InventoryObject> InventoryMenuItemSelected;
    private InventoryObject associatedInventoryObject;
    public InventoryObject AssociatedInventoryObject
    {
        get { return associatedInventoryObject; }
        set
        {
            associatedInventoryObject = value;
            iconImage.sprite = associatedInventoryObject.Icon;
        }
    }
    /// <summary>
    /// This wil be plugged into the toggle's "OnValueChanged" property in the editor and called when the toggle is clicked.
    /// </summary>
    public void InventoryMenuItemWasToggled(bool isOn)
    {
        //Only do this when the toggle has been SELECTED, not when DESELECTED.
        if (isOn)
        {
            InventoryMenuItemSelected?.Invoke(AssociatedInventoryObject);
        }
        Debug.Log($"Toggled: {isOn}");
    }
    private void Awake()
    {
        Toggle toggle = GetComponent<Toggle>();
        ToggleGroup toggleGroup = GetComponentInParent<ToggleGroup>();
        toggle.group = toggleGroup;
    }
} 
