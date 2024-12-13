using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Controllers
{
    public class TableController : MonoBehaviour
    {
        [SerializeField] private BackpackController backpackController;
        [SerializeField] private List<Transform> transformSlots;
        
        public void PickupItem(InventoryItemController item)
        {
            Transform transformSlot = transformSlots[item.Model.Id];
            
            item.Move(transformSlot.position, transformSlot.rotation);

            ToggleInteractionsAsync(item, true).Forget();
        }

        private static async UniTask ToggleInteractionsAsync(InventoryItemController item, bool value)
        {
            await UniTask.WaitForSeconds(InventoryItemController.MoveDuration);
            item.ToggleInteractions(value);
        }
    }
}