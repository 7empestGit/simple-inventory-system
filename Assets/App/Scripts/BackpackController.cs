using System;
using System.Collections.Generic;
using System.Linq;
using App.Enums;
using App.Models;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace App
{
    public class BackpackController : MonoBehaviour
    {
        [SerializeField] private InventoryViewController inventoryViewController;
        [SerializeField] private TableController tableController;
        [SerializeField] private List<ItemTransformData> transformData;
        
        [Space]
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
            if (selectedSlot != null && selectedSlot.Item != null)
            {
                PutOutBackpack(selectedSlot.Item);
            }
            
            inventoryViewController.ToggleView(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out InventoryItemController item))
                return;

            if (!item.IsInteractable)
                return;
            
            item.ToggleInteractions(false);
            PutInBackpack(item);
        }

        #endregion

        public async void PutInBackpack(InventoryItemController item)
        {
            bool result = await NetworkManager.Instance.ExecuteInventoryAction(item.Model, InventoryActionType.PutIn);

            if (!result)
                return;
            
            MoveItem(item);
            inventoryViewController.PutIn(item);
            OnItemPutIn?.Invoke();
        }

        public async void PutOutBackpack(InventoryItemController item)
        {
            bool result = await NetworkManager.Instance.ExecuteInventoryAction(item.Model, InventoryActionType.PutOut);

            if (!result)
                return;
            
            tableController.PickupItem(item);
            inventoryViewController.PutOut(item);
            OnItemPutOut?.Invoke();
        }

        private void MoveItem(InventoryItemController item)
        {
            Transform itemTransform = GetItemTransform(item);
            item.Move(itemTransform.position, itemTransform.rotation);
        }

        private Transform GetItemTransform(InventoryItemController item)
        {
            Transform targetTransform = transformData.FirstOrDefault(i => i.ItemId == item.Model.Id)?.Transform;
            
            if (item == null || targetTransform == null)
                return transform;
            
            return targetTransform;
        }
    }
}