using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject inventoryMenuItemTogglePrefab;
    [Tooltip("Place in UI for displaying the selected inventory item name.")]
    [SerializeField]
    private Text itemLabelText;
    [Tooltip("Place in UI for displaying the selected inventory item info.")]
    [SerializeField]
    private Text descriptionAreaText;
    [Tooltip("Content of the scrollview for the list of inventory items.")]
    [SerializeField]
    private Transform inventoryListContentArea;
    private static InventoryMenu instance;
    private CanvasGroup canvasGroup;
    private RigidbodyFirstPersonController fpsController;
    private AudioSource audioSource;
    public static InventoryMenu Instance
    {
        get
        {
            if (instance == null)
            {
                throw new System.Exception("There is currently no InventoryMenu instance but you are trying to access it."
                    + "Make sure the InventoryMenu script is applied to a game object in your scene!");
            }
            return instance;
        }
        private set { instance = value; }
    }
    private bool IsVisible => canvasGroup.alpha > 0;
    public void ExitMenuButtonClicked()
    {
        HideMenu();
    }
    /// <summary>
    /// Instatiates a new InventoryMenuItemToggle prefab and adds it to menu.
    /// </summary>
    /// <param name="inventoryObjectToAdd"></param>
    public void AddItemToMenu(InventoryObject inventoryObjectToAdd)
    {
        GameObject clone = Instantiate(inventoryMenuItemTogglePrefab, inventoryListContentArea);
        InventoryMenuItemToggle toggle = clone.GetComponent<InventoryMenuItemToggle>();
        toggle.AssociatedInventoryObject = inventoryObjectToAdd;
    }
    private void ShowMenu()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        fpsController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        audioSource.Play();
    }
    private void HideMenu()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        fpsController.enabled = true;
        audioSource.Play();
    }
    /// <summary>
    /// The event handler for InventoryMenuItemSelected
    /// </summary>
    /// <param name="inventoryObjectThatWasSelected"></param>
    private void OnInventoryMenuItemSelected(InventoryObject inventoryObjectThatWasSelected)
    {
        itemLabelText.text = inventoryObjectThatWasSelected.ObjectName;
        descriptionAreaText.text = inventoryObjectThatWasSelected.Description;
    }
    private void OnEnable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected += OnInventoryMenuItemSelected;
    }
    private void OnDisable()
    {
        InventoryMenuItemToggle.InventoryMenuItemSelected -= OnInventoryMenuItemSelected;
    }
    private void Update()
    {
        HandleInput();
    }
    private void HandleInput()
    {
        if (Input.GetButtonDown("Show Inventory Menu"))
        {
            if (IsVisible)
                HideMenu();
            else
                ShowMenu();
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            throw new System.Exception("There is already an instance of InventoryMenu and there can only be one.");

        canvasGroup = GetComponent<CanvasGroup>();
        fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        HideMenu();
        StartCoroutine(WaitForSoundClip());
    }
    private IEnumerator WaitForSoundClip()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume = 0;
        Debug.Log("Start waiting.");
        yield return new WaitForSeconds(audioSource.clip.length);
        Debug.Log("Done waiting.");
        audioSource.volume = originalVolume;
    }
} 
