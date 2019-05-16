using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cook : InteractiveObject
{
        [SerializeField]
        private InventoryObject ingredient;
    [SerializeField]
        private bool consumesIngredient;
        [SerializeField]
        private InventoryObject meal;
        [SerializeField]
        private string nocookDisplayText = "Missing Ingredients";
        [SerializeField]
        private AudioClip nocookAudioClip;
        [SerializeField]
        private AudioClip cookAudioClip;
        private bool HasIngredient => PlayerInventory.InventoryObjects.Contains(ingredient);
        private bool isLocked = false;
        private bool isOpen = false;
        public override string DisplayText
        {
            get
            {
                string toReturn;

                if (isLocked)
                    toReturn = HasIngredient ? $"Cook?" : nocookDisplayText;
                else
                    toReturn = base.DisplayText;
                return toReturn;
            }
        }
        /// <summary>
        /// Using a constructor here to intialize displayText in the editor.
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            InitializeisLocked();
        }
        private void InitializeisLocked()
        {
            if (ingredient != null)
                isLocked = true;
        }
        public override void InteractWith()
        {
            if (!isOpen)
            {
                if (isLocked && !HasIngredient)
                {
                    audioSource.clip = nocookAudioClip;
                }
                else 
                {
                    audioSource.clip = cookAudioClip;
                    displayText = string.Empty;
                    isOpen = true;
                    CookMeal();
                }
                base.InteractWith();//this plays a sound effect!
            }
        }
        private void CookMeal()
        {
            isLocked = false;
            if (ingredient != null && consumesIngredient)
                PlayerInventory.InventoryObjects.Remove(ingredient);
                PlayerInventory.InventoryObjects.Add(meal);
                InventoryMenu.Instance.AddItemToMenu(meal);
    }
    }
