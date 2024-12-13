using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using UnityEngine;

namespace App
{
    public class InventoryViewController : MonoBehaviour
    {
        [SerializeField] private List<InventorySlotController> slots;
        [SerializeField] private GameObject view;

        public InventorySlotController SelectedSlot => slots.FirstOrDefault(i => i.IsSelected);
        
        public void ToggleView(bool value)
        {
            view.SetActive(value);
        }

        public void PutOut(InventoryItemController item)
        {
            slots.First(i => i.Item.Model.Id == item.Model.Id).Initialize(null); // empty the slot
        }

        public void PutIn(InventoryItemController item)
        {
            InventorySlotController emptySlot = slots.FirstOrDefault(i => i.Item == null);
            
            if (emptySlot == null)
            {
                Debug.LogError("No empty slots available!");
                return;
            }

            emptySlot.Initialize(item);
        }
    }
}