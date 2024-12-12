using System;
using App.Enums;
using App.Models;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace App
{
    public class BackpackController : MonoBehaviour
    {
        [SerializeField] private InventoryViewController inventoryViewController;
        // TO DO: Table controller
        
        public UnityEvent OnItemPutIn;
        public UnityEvent OnItemPutOut;
        
        #region Unity Methods

        private void OnMouseDown()
        {
            inventoryViewController.ToggleView(true);
        }

        private void OnMouseUp()
        {
            InventorySlotController selectedSlot = inventoryViewController.SelectedSlot;
            if (selectedSlot != null)
            {
                PutOutBackpack(selectedSlot.Model);
            }
            
            inventoryViewController.ToggleView(false);
        }

        #endregion

        private async void PutInBackpack(InventoryItemModel item)
        {
            bool result = await NetworkManager.Instance.ExecuteInventoryAction(item, InventoryActionType.PutIn);
            Debug.Log($"Item PutInBackpack: {result}");
            OnItemPutIn?.Invoke();
        }

        private async void PutOutBackpack(InventoryItemModel item)
        {
            // TO DO: Call table controller's paste function
            inventoryViewController.PutOut(item);
            bool result = await NetworkManager.Instance.ExecuteInventoryAction(item, InventoryActionType.PutOut);
            Debug.Log($"Item PutOutBackpack: {result}");
            OnItemPutOut?.Invoke();
        }
    }
}