using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Controllers
{
    public class InventorySlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("UI")]
        [SerializeField] private Image image;
        [SerializeField] private Image iconImage;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color selectedColor;

        [Space]
        [SerializeField] private InventoryItemController item;
        public InventoryItemController Item => item;

        public bool IsSelected { get; private set; }

        public void Initialize(InventoryItemController targetItem)
        {
            item = targetItem;
            iconImage.sprite = item?.Model?.Sprite;
            IsSelected = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsSelected = true;
            image.color = selectedColor;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsSelected = false;
            image.color = defaultColor;
        }
    }
}