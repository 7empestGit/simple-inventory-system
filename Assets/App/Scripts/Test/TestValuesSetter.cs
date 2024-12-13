using System.Collections.Generic;
using App.Controllers;
using UnityEngine;

namespace App.Test
{
    public class TestValuesSetter : MonoBehaviour
    {
        [SerializeField] private List<InventoryItemController> inventoryItems;
        [SerializeField] private TableController tableController;

        #region Unity Methods

        private void Awake()
        {
            foreach (InventoryItemController item in inventoryItems)
            {
                item.ToggleInteractions(false);
                tableController.PickupItem(item);
            }
        }

        #endregion
    }
}