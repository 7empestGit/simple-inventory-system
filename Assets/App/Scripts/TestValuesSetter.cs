using System;
using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class TestValuesSetter : MonoBehaviour
    {
        [SerializeField] private List<InventoryItemController> inventoryItems;
        [SerializeField] private BackpackController backpackController;

        #region Unity Methods

        private void Awake()
        {
            inventoryItems.ForEach(i => backpackController.PutInBackpack(i));
        }

        #endregion
    }
}