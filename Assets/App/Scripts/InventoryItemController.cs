using System;
using App.Models;
using UnityEngine;
using DG.Tweening;

namespace App
{
    public class InventoryItemController : MonoBehaviour, IMovable
    {
        [SerializeField] private InventoryItemModel model;
        public InventoryItemModel Model => model;

        public Action ClickHandler { get; set; }

        public void Move(Vector3 position, Quaternion rotation)
        {
            transform.DOMove(position, 1.0f);
            transform.DORotateQuaternion(rotation, 1.0f);
        }

        public void OnMouseUpAsButton()
        {
            ClickHandler?.Invoke();
        }
    }
}