using System.Collections.Generic;
using UnityEngine;

namespace App
{
    public class TableController : MonoBehaviour
    {
        [SerializeField] private BackpackController backpackController;
        [SerializeField] private List<Transform> transformSlots;
        
        public void PickupItem(InventoryItemController item)
        {
            item.ClickHandler = () => PutOutItem(item);
            Transform transformSlot = transformSlots[item.Model.Id];
            item.Move(transformSlot.position, transformSlot.rotation);
        }

        private void PutOutItem(InventoryItemController item)
        {
            item.ClickHandler = null;
            backpackController.PutInBackpack(item);
        }
    }
}