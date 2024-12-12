using System;
using App.Models;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App
{
    public class InventorySlotController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [Header("UI")]
        [SerializeField] private Image image;
        [SerializeField] private Image iconImage;
        [SerializeField] private Color defaultColor;
        [SerializeField] private Color selectedColor;

        [Space]
        [SerializeField] private InventoryItemModel model;

        public InventoryItemModel Model => model;

        public bool IsSelected { get; private set; }

        public void Initialize()
        {
            
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

        public void Empty()
        {
            model = new InventoryItemModel();
            iconImage = null;
        }
    }
}