using App.Enums;

namespace App.Models
{
    [System.Serializable]
    public class InventoryActionPayloadModel
    {
        public int Id { get; set; }
        public string Action { get; set; }

        public InventoryActionPayloadModel(int id, InventoryActionType action)
        {
            Id = id;
            Action = action.ToString();
        }
    }
}