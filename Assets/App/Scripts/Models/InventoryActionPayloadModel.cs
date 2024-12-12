using App.Enums;

namespace App.Models
{
    [System.Serializable]
    public class InventoryActionPayloadModel
    {
        public int Id;
        public string Action;

        public InventoryActionPayloadModel(int id, InventoryActionType action)
        {
            Id = id;
            Action = action.ToString();
        }
    }
}