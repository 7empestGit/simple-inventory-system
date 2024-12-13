using App.Enums;
using UnityEngine;

namespace App.Models
{
    [System.Serializable]
    public class InventoryItemModel
    {
        public int Id;
        public string Name;
        public float Weight;
        public InventoryItemType Type;
        public Sprite Sprite;
    }
}