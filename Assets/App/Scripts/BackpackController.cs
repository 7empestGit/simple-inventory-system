using System;
using App.Enums;
using App.Models;
using UnityEngine;
using UnityEngine.Events;

namespace App
{
    public class BackpackController : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        
        public UnityEvent OnItemPutIn;
        public UnityEvent OnItemPutOut;
        
        #region Unity Methods

        private void OnMouseDown()
        {
            inventoryPanel.SetActive(true);
        }

        #endregion
        
        public async void PutInBackpack()
        {
            InventoryItemModel inventoryItem = new InventoryItemModel();
            bool result = await NetworkManager.Instance.ExecuteInventoryAction(inventoryItem, InventoryActionType.PutIn);
            Debug.Log($"Item PutInBackpack: {result}");
            OnItemPutIn?.Invoke();
        }

        public async void PutOutBackpack()
        {
            InventoryItemModel inventoryItem = new InventoryItemModel();
            bool result = await NetworkManager.Instance.ExecuteInventoryAction(inventoryItem, InventoryActionType.PutOut);
            Debug.Log($"Item PutOutBackpack: {result}");
            OnItemPutOut?.Invoke();
        }
        
        
    }
}