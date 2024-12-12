using App.Enums;

namespace App.Models
{
    [System.Serializable]
    public class InventoryItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public InventoryItemType Type { get; set; }
    }
}