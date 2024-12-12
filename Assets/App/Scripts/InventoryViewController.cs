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

        #region Unity Methods

        private void Awake()
        {
            slots.ForEach(i => i.Initialize());
        }

        #endregion
        
        public void ToggleView(bool value)
        {
            view.SetActive(value);
        }

        public void PutOut(InventoryItemModel item)
        {
            slots.First(i => i.Model.Id == item.Id).Empty();
        }
    }
}