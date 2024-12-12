using App.Enums;

namespace App.Models
{
    [System.Serializable]
    public class InventoryItemModel
    {
        public int Id;
        public string Name;
        public float Weight;
        public InventoryItemType Type;
    }
}